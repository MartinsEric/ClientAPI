namespace Domain.Interfaces.UseCases
{
    public interface IDeleteClientUseCase
    {
        Task Execute(Guid clientId);
    }
}
