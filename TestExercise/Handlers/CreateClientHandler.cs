using AutoMapper;
using Domain.Abstract;
using Domain.Contract;
using Domain.Model;
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
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, ErrorResponse>
    {
        private readonly IMapper mapper;
        private readonly IClientRepository clientRepository;

        public CreateClientHandler(IMapper mapper,IClientRepository clientRepository)
        {
            this.mapper = mapper;
            this.clientRepository = clientRepository;
        }
        public Task<ErrorResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = mapper.Map<Client>(request.CreateClientContract);
            clientRepository.AddEntity(client);
            return Task.Run(() => new ErrorResponse());
        }
    }
}
