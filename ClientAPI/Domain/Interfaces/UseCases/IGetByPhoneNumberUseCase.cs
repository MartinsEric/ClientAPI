using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
    public interface IGetByPhoneNumberUseCase
    {
        Task<Client> Execute(string phoneNumber);
    }
}
