using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Application.UseCases
{
    public class GetAllClientsUseCase : UseCaseBase, IGetAllClientsUseCase
    {
        public GetAllClientsUseCase(IClientRepository clientRepository) : base(clientRepository) { }
        
        public Task<IEnumerable<Client>> Execute()
        {
            return _clientRepository.GetAll();
        }
    }
}