using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Application.UseCases
{
    public class GetByPhoneNumberUseCase : UseCaseBase, IGetByPhoneNumberUseCase
    {
        public GetByPhoneNumberUseCase(IClientRepository clientRepository) : base(clientRepository) { }

        public Task<Client> Execute(string phoneNumber)
        {
            return _clientRepository.GetByPhoneNumber(phoneNumber);
        }
    }
}
