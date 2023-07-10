using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
    public interface IAddClientUseCase
    {
        Task Execute(Client client);
    }
}
