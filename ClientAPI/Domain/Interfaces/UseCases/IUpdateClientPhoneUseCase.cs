using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
    public interface IUpdateClientPhoneUseCase
    {
        Task Execute(string email, string phoneNumber, PhoneNumber newPhoneNumber);
    }
}
