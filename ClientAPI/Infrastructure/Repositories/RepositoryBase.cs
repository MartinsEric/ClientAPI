using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly AppDbContext _dbContext;

        public RepositoryBase(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
    }
}
