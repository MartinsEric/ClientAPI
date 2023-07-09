namespace Domain.Entities
{
    internal class Client
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public IEnumerable<PhoneNumber> Phones{ get; private set; }

        public Client(string name, string email)
        {
            Id = Guid.NewGuid();
            Phones = new List<PhoneNumber>();  
            Name = name;   
            Email = email;
        }

        public void UpdateEmail(string email)
        {
            this.Email = email;
        }

        public void UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            var phone = Phones.FirstOrDefault(p => p.ToString() == phoneNumber.ToString());
            
            if (phone != null)
            {
                phone.UpdatePhoneNumber(phoneNumber);
            }
        }
    }
}