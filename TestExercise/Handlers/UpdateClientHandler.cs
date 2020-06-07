using AutoMapper;
using Domain.Abstract;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestExercise.Commands;

namespace TestExercise.Handlers
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, object>
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public UpdateClientHandler(IClientRepository clientRepository,IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }
        public async Task<object> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {

            var client = mapper.Map<Client>(request.UpdateClient);
            return await Task.Run(() => clientRepository.Update(client));
        }
    }
}
