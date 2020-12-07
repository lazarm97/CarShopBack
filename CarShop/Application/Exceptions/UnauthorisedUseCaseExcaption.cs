using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class UnauthorisedUseCaseException : Exception
    {
        public UnauthorisedUseCaseException(IUseCase useCase, IApplicationActor actor)
            : base($"Actor with an id of {actor.Id} - {actor.Identity} tried to execute {useCase.Name}.")
        {

        }
    }
}
