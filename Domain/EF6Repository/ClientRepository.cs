using Domain.Abstract;
using Domain.Context;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.EF6Repository
{
    public class ClientRepository : RepositoryBase<Client>,IClientRepository
    {
        private ClientContext clientContext;
        public ClientRepository(ClientContext dbContext)
            : base(dbContext)
        {
            clientContext = dbContext;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return clientContext.Clients.Include(s => s.Constitutors);
        }
    }
}
