using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PhoneNumberRepository : RepositoryBase, IPhoneNumberRepository
    {
        public PhoneNumberRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task Update(PhoneNumber phoneNumber)
        {
            _dbContext.PhoneNumbers.Update(phoneNumber);
            await _dbContext.SaveChangesAsync();
        }
    }
}
