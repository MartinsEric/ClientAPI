using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Application.UseCases
{
    public class DeleteClientUseCase : UseCaseBase, IDeleteClientUseCase
    {
        public DeleteClientUseCase(IClientRepository clientRepository) : base(clientRepository) { }

        public async Task Execute(Guid clientId)
        {
            var client = await _clientRepository.GetById(clientId) ?? throw new ClientNotFoundException(clientId);
            await _clientRepository.Delete(client);
        }
    }
}
