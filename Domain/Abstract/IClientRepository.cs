using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IClientRepository : IRepository<Client>
    {
        IEnumerable<Client> GetAllClients();
        Guid Update(Client client);

        void DeleteClientById(Guid guid);
    }
}
