using Domain.Enums;

namespace Domain.Entities
{
    public class PhoneNumber
    {
        public Guid Id { get; private set; }
        public string DDD { get; private set; }
        public string Number { get; private set; }
        public PhoneType Type { get; private set; }

        protected PhoneNumber() { }

        public PhoneNumber(string ddd, string number, PhoneType type)
        {
            Id = Guid.NewGuid();
            DDD = ddd;
            Number = number;
            Type = type;
        }

        public void UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            DDD = phoneNumber.DDD;
            Number = phoneNumber.Number;    
            Type = phoneNumber.Type;
        }

        public override string ToString()
        {
            return DDD + Number;
        }
    }
}
