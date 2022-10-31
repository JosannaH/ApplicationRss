using System;

namespace BusinessLogic.Exceptions
{
    internal class ListNotAccessableException : Exception
    {
        public ListNotAccessableException(string message) : base(message)
        {

        }
    }
}
