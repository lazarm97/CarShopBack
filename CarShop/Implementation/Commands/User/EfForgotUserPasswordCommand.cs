using Application.Commands.User;
using Application.DTO;
using Application.Email;
using Application.Exceptions;
using EfDataAccess;
using Hangfire;
using System;
using System.Linq;

namespace Implementation.Commands.User
{
    public class EfForgotUserPasswordCommand : IForgotUserPasswordCommand
    {
        private readonly EfContext _context;
        private readonly IEmailSender emailSender;
        private readonly IBackgroundJobClient backgroundJobClient;

        public EfForgotUserPasswordCommand(EfContext context, IEmailSender emailSender, IBackgroundJobClient backgroundJobClient)
        {
            _context = context;
            this.emailSender = emailSender;
            this.backgroundJobClient = backgroundJobClient;
        }

        public int Id => 37;

        public string Name => "Forgot user password";

        public void Execute(ForgotPasswordDto request)
        {
            var user = _context.Users.Where(x => x.Email == request.Email).FirstOrDefault();

            if (user == null)
                throw new Exception("Korisnik sa ovim email-om ne postoji");

            var time = DateTime.Now.ToFileTime().ToString();
            var key = Guid.NewGuid().ToString();
            string token = time + key;
            var url = "http://localhost:4200/reset-password?user=" + request.Email + "&token=" + token;

            user.Token = token;
            _context.SaveChanges();

            emailSender.Send(new SendEmailDto
            {
                Content = url,
                SendTo = request.Email,
                Subject = "Reset password"
            });

            backgroundJobClient.Schedule(
                    () => RemoveToken(request.Email),
                    TimeSpan.FromHours(24)
                );
        }

        public void RemoveToken(string email)
        {
            var user = _context.Users.Where(x => x.Email == email).FirstOrDefault();
            user.Token = null;
            this._context.SaveChanges();
        }
    }
}
