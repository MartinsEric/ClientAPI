using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
    internal interface IAddClientUseCase
    {
        Task Execute(Client client);
    }
}
