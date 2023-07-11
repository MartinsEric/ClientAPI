namespace Domain.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(string email) 
            : base($"Client with the email {email} was not found."){ }
    }
}
