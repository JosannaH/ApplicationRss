using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions
{
    internal class ListNotAccessableException : Exception
    {
        public ListNotAccessableException(string message) : base(message)
        {

        }
    }
}
