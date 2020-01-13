using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SpiceRoad.Exceptions
{
    public class NoEntityFoundWithIdException<T> : Exception
    {
        public NoEntityFoundWithIdException(Guid id) : base($"No {typeof(T).Name} found with {id}.")
        {
        }
    }
}
