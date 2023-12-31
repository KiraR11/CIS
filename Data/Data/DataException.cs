﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    internal class DataException : Exception
    {
        public DataException(string message, string pathError): base (message)  
        { 
            PathError = pathError;
        }
        public DataException(string message) : base(message)
        {  
        }
        public string? PathError { get; }
    }
}
