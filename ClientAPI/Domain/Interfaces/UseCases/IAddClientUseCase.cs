using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
    public interface IAddClientUseCase
    {
        Task Execute(AddClientDTO clientDTO);
    }
}
