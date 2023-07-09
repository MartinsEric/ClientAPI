namespace Domain.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(Guid id) 
            : base($"Client with the Id = {id} was not found."){ }
    }
}
