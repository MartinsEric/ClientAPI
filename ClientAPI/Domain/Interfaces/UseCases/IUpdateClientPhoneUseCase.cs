using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
    public interface IUpdateClientPhoneUseCase
    {
        Task Execute(Guid clientId, string phoneNumber, PhoneNumber newPhoneNumber);
    }
}
