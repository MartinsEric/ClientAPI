using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();
        Client GetByPhoneNumber(string phoneNumber);
        void Add(Client cliente);
        void Update(Client cliente);
        void Delete(Guid id);
        
    }
}
