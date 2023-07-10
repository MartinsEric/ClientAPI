namespace Domain.Entities
{
    public class Client
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public IEnumerable<PhoneNumber> Phones{ get; private set; }

        public Client(string name, string email, IEnumerable<PhoneNumber> phones)
        {
            Id = Guid.NewGuid(); 
            Phones = phones ?? new List<PhoneNumber>();
            Name = name;   
            Email = email;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }
    }
}