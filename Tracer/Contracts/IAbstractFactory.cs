using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace = Tracer.TraceResult;

namespace Tracer.Contracts
{

    public interface IDelegateAbstractFactory<T> where T : Delegate
    {
        T CreateSnapshot();
    }
}
