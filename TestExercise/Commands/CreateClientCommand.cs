using Domain.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExercise.Commands
{
    public class CreateClientCommand : IRequest<ErrorResponse>
    {
        public CreateClientContract CreateClientContract { get; set; }

        public CreateClientCommand(CreateClientContract createClientContract)
        {
            CreateClientContract = createClientContract;
        }
    }
}
