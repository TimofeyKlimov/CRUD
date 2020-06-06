using Domain.DTO;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExercise.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<ClientDTO>>
    {
    }
}
