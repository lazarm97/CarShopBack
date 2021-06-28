using Application;
using Application.Commands.Brand;
using Application.Commands.Car;
using Application.Commands.Color;
using Application.Commands.Model;
using Application.Commands.Reservation;
using Application.Commands.User;
using Application.Helpers;
using Application.Queries.Brand;
using Application.Queries.Car;
using Application.Queries.Color;
using Application.Queries.Help;
using Application.Queries.Model;
using Application.Queries.Reservation;
using Application.Queries.User;
using EfDataAccess;
using Hangfire;
using Hangfire.MemoryStorage;
using Implementation.Commands.Brand;
using Implementation.Commands.Car;
using Implementation.Commands.Color;
using Implementation.Commands.Model;
using Implementation.Commands.Reservation;
using Implementation.Commands.User;
using Implementation.Helpers;
using Implementation.Queries.Brand;
using Implementation.Queries.Car;
using Implementation.Queries.Color;
using Implementation.Queries.Fuel;
using Implementation.Queries.Help;
using Implementation.Queries.Model;
using Implementation.Queries.Reservation;
using Implementation.Queries.User;
using Implementation.Validators.Car;
using Implementation.Validators.Reservation;
using Implementation.Validators.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Text;

namespace CarShop.Core
{
    public static class ContainerExtensions
    {
        public static void AddUsesCases(this IServiceCollection services)
        {
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            services.AddTransient<IDeleteReservationCommand, EfDeleteReservationCommand>();
            services.AddTransient<IGetUserQuery, EfGetUser>();
            services.AddTransient<IGetCarsQuery, EfGetCars>();
            services.AddTransient<IGetCarQuery, EfGetCar>();
            services.AddTransient<IDeleteCarCommand, EfDeleteCarCommand>();
            services.AddTransient<IGetNewReservationInfoQuery, EfGetNewReservationInfoQuery>();
            services.AddTransient<IGetModelsQuery, EfGetModelsQuery>();
            services.AddTransient<ICreateReservationCommand, EfCreateReservationCommand>();
            services.AddTransient<IGetReservationQuery, EfGetUserReservationsQuery>();
            services.AddTransient<IGetReservationsQuery, EfGetReservationsQuery>();
            services.AddTransient<IGetNewCarInfoQuery, EfGetNewCarInfoQuery>();
            services.AddTransient<IEditReservationCommand, EfEditReservationCommand>();
            services.AddTransient<ICreateCarCommand, EfCreateCarCommand>();
            services.AddTransient<IEditCarCommand, EfEditCarCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IResetUserPasswordCommand, EfResetUserPasswordCommand>();
            services.AddTransient<IGetColorsQuery, EfGetColorsQuery>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();
            services.AddTransient<IDeleteColorCommand, EfDeleteColorCommand>();
            services.AddTransient<IDeleteModelCommand, EfDeleteModelCommand>();
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();
            services.AddTransient<ICreateModelCommand, EfCreateModelCommand>();
            services.AddTransient<ICreateColorCommand, EfCreateColorCommand>();
            services.AddTransient<IEditBrandCommand, EfEditBrandCommand>();
            services.AddTransient<IEditColorCommand, EfEditColorCommand>();
            services.AddTransient<IEditModelCommand, EfEditModelCommand>();
            services.AddTransient<IForgotUserPasswordCommand, EfForgotUserPasswordCommand>();
            services.AddTransient<ICreateUserPasswordCommand, EfCreateUserPasswordCommand>();
            services.AddTransient<IGetUserBanQuery, EfGetBanUsers>();
            services.AddTransient<IActivateBannedUserCommand, EfAtivateBannedUserCommand>();
            services.AddTransient<IGetReservationsStatisticQuery, EfGetReservationsStatisticQuery>();
            //validators
            services.AddTransient<CreateReservationValidate>();
            services.AddTransient<EditReservationValidate>();
            services.AddTransient<DeleteReservationValidate>();
            services.AddTransient<EditUserValidate>();
            services.AddTransient<GetUserReservationsValidate>();
            services.AddTransient<LogUserValidate>();
            services.AddTransient<CreateCarValidate>();
            services.AddTransient<DeleteCarValidate>();
            services.AddTransient<EditCarValidate>();
            services.AddTransient<ResetPasswordValidate>();
        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
        }

        public static void AddJwt(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<EfContext>();

                return new JwtManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddHangfireService(this IServiceCollection services)
        {
            services.AddHangfire(config =>
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseMemoryStorage()
            );

            services.AddHangfireServer();
        }
    }
}
