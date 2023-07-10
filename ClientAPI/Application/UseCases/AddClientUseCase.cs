using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Application.UseCases
{
    public class AddClientUseCase : UseCaseBase, IAddClientUseCase
    {
        public AddClientUseCase(IClientRepository clientRepository) : base(clientRepository) { }

        public Task Execute(Client client)
        {
            return _clientRepository.Add(client);
        }
    }
}
