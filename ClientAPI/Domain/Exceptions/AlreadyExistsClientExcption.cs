namespace Domain.Exceptions
{
    public class AlreadyExistsClientExcption : Exception
    {
        public AlreadyExistsClientExcption(string email) 
            : base($"Client with the email {email} already exists.") { }
    }
}
