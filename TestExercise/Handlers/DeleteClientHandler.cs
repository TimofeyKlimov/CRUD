using Domain.Abstract;
using Domain.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestExercise.Commands;

namespace TestExercise.Handlers
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, ErrorResponse>
    {
        private readonly IClientRepository repository;

        public DeleteClientHandler(IClientRepository repository)
        {
            this.repository = repository;
        }
        public Task<ErrorResponse> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            repository.DeleteClientById(request.Contract.Id);
            return Task.Run(() => new ErrorResponse());
        }
    }
}
