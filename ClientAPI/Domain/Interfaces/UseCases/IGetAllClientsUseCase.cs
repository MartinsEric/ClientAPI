using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
    public interface IGetAllClientsUseCase
    {
        Task<IEnumerable<Client>> Execute();
    }
}
