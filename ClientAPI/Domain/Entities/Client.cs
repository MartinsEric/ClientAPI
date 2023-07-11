namespace Domain.Entities
{
    public class Client
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public ICollection<PhoneNumber> Phones{ get; private set; }

        protected Client() { }

        public Client(string name, string email)
        {
            Id = Guid.NewGuid(); 
            Phones = new List<PhoneNumber>();
            Name = name;   
            Email = email;
        }

        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            Phones.Add(phoneNumber);
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }
    }
}