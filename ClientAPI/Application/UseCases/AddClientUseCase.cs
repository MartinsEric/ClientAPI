using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Application.UseCases
{
    public class AddClientUseCase : UseCaseBase, IAddClientUseCase
    {
        public AddClientUseCase(IClientRepository clientRepository) : base(clientRepository) { }

        public async Task Execute(AddClientDTO clientDTO)
        {
            var existingClient = await _clientRepository.GetByEmail(clientDTO.Email);

            if(existingClient is not null) throw new AlreadyExistsClientExcption(clientDTO.Email);

            var client = clientDTO.Transform();
            await _clientRepository.Add(client);
        }
    }
}
