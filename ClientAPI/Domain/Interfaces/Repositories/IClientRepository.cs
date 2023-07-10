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
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetByPhoneNumber(string phoneNumber);
        Task Add(Client cliente);
        Task Update(Client cliente);
        Task Delete(Guid id);
        
    }
}
