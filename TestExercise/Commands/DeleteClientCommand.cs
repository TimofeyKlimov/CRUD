using Domain.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercise.Commands
{
    public class DeleteClientCommand : IRequest<ErrorResponse>
    {

        public DeleteClientCommand(DeleteClientContract contract)
        {
            Contract = contract;
        }

        public DeleteClientContract Contract { get; }
    }
}
