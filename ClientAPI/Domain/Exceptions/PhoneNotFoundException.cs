namespace Domain.Exceptions
{
    public class PhoneNotFoundException : Exception
    {
        public PhoneNotFoundException(string phoneNumber) 
            : base($"The phone number {phoneNumber} was not found.") { }
        
    }
}
