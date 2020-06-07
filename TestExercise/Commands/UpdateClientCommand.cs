using Domain.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExercise.Commands
{
    public class UpdateClientCommand : IRequest<object>
    {

        public UpdateClientCommand(UpdateClientContract updateClient)
        {
            UpdateClient = updateClient;
        }

        public UpdateClientContract UpdateClient { get; }
    }
}
