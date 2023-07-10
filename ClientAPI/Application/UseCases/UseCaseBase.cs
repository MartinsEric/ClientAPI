using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public abstract class UseCaseBase
    {
        protected readonly IClientRepository _clientRepository;

        public UseCaseBase(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
    }
}
