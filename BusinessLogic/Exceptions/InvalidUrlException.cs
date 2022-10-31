﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions
{
    public class InvalidUrlException : Exception
    {

        public InvalidUrlException(string message) : base(message)
        {

        }
    }

}
