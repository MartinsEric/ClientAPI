using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class PhoneNotFoundException : Exception
    {
        public PhoneNotFoundException(string phoneNumber) 
            : base($"The phone number {phoneNumber} was not found.") { }
        
    }
}
