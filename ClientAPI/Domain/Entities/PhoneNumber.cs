using Domain.Enums;
using System.Data;
using System.Reflection.PortableExecutable;

namespace Domain.Entities
{
    internal class PhoneNumber
    {
        public string DDD { get; private set; }
        public string Number { get; private set; }
        public PhoneType Type { get; private set; }

        public PhoneNumber(string ddd, string number, PhoneType type)
        {
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
