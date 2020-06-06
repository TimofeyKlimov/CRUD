using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstract
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
    }
}
