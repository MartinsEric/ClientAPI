namespace Domain.Interfaces.UseCases
{
    public interface IDeleteClientUseCase
    {
        Task Execute(string email);
    }
}
