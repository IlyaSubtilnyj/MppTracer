using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace = Tracer.TraceResult;

namespace Tracer.Contracts
{
    /// <summary>
    /// Deprecated
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDelegateAbstractFactory<T> where T : Delegate
    {
        T CreateSnapshot();
    }
}
