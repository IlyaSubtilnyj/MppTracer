using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace = Tracer.TraceResult;

namespace Tracer.Contracts
{

    public delegate Trace.TraceResult PrintOperation();

    public interface IAbstractFactory
    {
        PrintOperation CreateTraceResult(int link);

    }
}
