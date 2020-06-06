using AutoMapper;
using Domain.Abstract;
using Domain.DTO;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestExercise.Queries;

namespace TestExercise.Handlers
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDTO>>
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;
        public GetAllClientsHandler(IClientRepository clientRepository,IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ClientDTO>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await Task.Run(() => clientRepository.GetAllClients());
            return mapper.Map<ClientDTO[]>(clients); 
        }
    }
}
