using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClientRepository : RepositoryBase, IClientRepository
    {

        public ClientRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task Add(Client client)
        {
            _dbContext.Clients.Add(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Client client)
        {
            _dbContext.Clients.Remove(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _dbContext.Clients
                .Include(c => c.Phones)
                .ToListAsync();
        }

        public async Task<Client?> GetByEmail(string email)
        {
            return await _dbContext.Clients
                .Include(c => c.Phones)
                .SingleOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Client?> GetById(Guid id)
        {
            return await _dbContext.Clients
                .Include(c => c.Phones)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client?> GetByPhoneNumber(string phoneNumber)
        {
            var clients = await _dbContext.Clients
                .Include(c => c.Phones)
                .ToListAsync();

            return clients.FirstOrDefault(c => c.Phones.Any(p => p.ToString() == phoneNumber));
        }

        public async Task Update(Client client)
        {
            _dbContext.Clients.Update(client);
            await _dbContext.SaveChangesAsync();
        }
    }
}
