﻿using Domain.Abstract;
using Domain.Context;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        public void DeleteClientById(Guid guid)
        {
            var client = clientContext.Clients.FirstOrDefault(s => s.Id == guid);
            if (client == null) return;
            clientContext.Clients.Remove(client);
            clientContext.Entry(client).State = EntityState.Deleted;
            clientContext.SaveChanges();
        }
        public Guid Update(Client updateClient)
        {
            var entity = clientContext.Set<Client>().First(s => s.Id == updateClient.Id);
            clientContext.Entry(entity).State = EntityState.Detached;
            updateClient.UpdateDate = DateTime.Now;
            clientContext.Entry(updateClient).State = EntityState.Modified;
            return updateClient.Id;
        }
    }
}
