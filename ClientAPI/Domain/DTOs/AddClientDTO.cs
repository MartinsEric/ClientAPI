using Domain.Entities;

namespace Domain.DTOs
{
    public class AddClientDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<AddPhoneNumberDTO> Phones { get; set; }

        public AddClientDTO(string name, string email, ICollection<AddPhoneNumberDTO> phones)
        {
            Name = name;
            Email = email;
            Phones = phones;
        }

        public Client Transform()
        {
            var client = new Client(Name, Email);
            Phones.ToList().ForEach(p => client.AddPhoneNumber(new PhoneNumber(p.DDD, p.Number, p.Type)));

            return client;
        }
    }
}
