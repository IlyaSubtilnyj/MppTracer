﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Exceptions
{

    public class LogicalException : Exception
    {
        public LogicalException(string message) : base(message)
        {
        }
    }
}
