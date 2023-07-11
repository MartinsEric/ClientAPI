namespace Domain.Interfaces.UseCases
{
    public interface IUpdateClientEmailUseCase
    {
        Task Execute(string email, string newEmail);
    }
}
