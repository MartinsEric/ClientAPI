namespace Domain.Interfaces.UseCases
{
    public interface IUpdateClientEmailUseCase
    {
        Task Execute(Guid clientId, string newEmail);
    }
}
