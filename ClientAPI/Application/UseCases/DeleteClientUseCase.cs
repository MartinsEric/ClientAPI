using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Application.UseCases
{
    public class DeleteClientUseCase : UseCaseBase, IDeleteClientUseCase
    {
        public DeleteClientUseCase(IClientRepository clientRepository) : base(clientRepository) { }

        public async Task Execute(string email)
        {
            var client = await _clientRepository.GetByEmail(email) ?? throw new ClientNotFoundException(email);
            await _clientRepository.Delete(client);
        }
    }
}
