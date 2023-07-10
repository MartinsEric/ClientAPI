using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class UpdateClientEmailUseCase : UseCaseBase, IUpdateClientEmailUseCase
    {
        public UpdateClientEmailUseCase(IClientRepository clientRepository) : base(clientRepository) { }

        public async Task Execute(Guid clientId, string newEmail)
        {
            var client = await _clientRepository.GetById(clientId) ?? throw new ClientNotFoundException(clientId);
            
            client.UpdateEmail(newEmail);
            await _clientRepository.Update(client);
        }
    }
}
