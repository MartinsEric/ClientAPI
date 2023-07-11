using Domain.Enums;

namespace Domain.DTOs
{
    public class AddPhoneNumberDTO
    {
        public string DDD { get; set; }
        public string Number { get; set; }
        public PhoneType Type { get; set; }

        public AddPhoneNumberDTO(string ddd, string number, PhoneType type)
        {
            DDD = ddd;
            Number = number;
            Type = type;
        }
    }
}
