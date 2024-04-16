using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.workspace.output
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string data)
        {

            Console.Write(data);
        }
    }   
}
