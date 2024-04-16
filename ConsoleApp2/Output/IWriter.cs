using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.workspace.output
{
    public interface IWriter
    {
        void Write(string data);
    }
}
