using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(Guid id) 
            : base($"Client with the Id = {id} was not found."){ }
    }
}
