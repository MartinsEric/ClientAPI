using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Application.UseCases
{
    public class AddClientUseCase : UseCaseBase, IAddClientUseCase
    {
        public AddClientUseCase(IClientRepository clientRepository) : base(clientRepository) { }

        public Task Execute(AddClientDTO clientDTO)
        {
            var client = clientDTO.Transform();
            return _clientRepository.Add(client);
        }
    }
}
