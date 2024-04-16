using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tracer
{
    public class TraceThread
    {

        public readonly int                 _id;
        public readonly double              _time;
        public readonly List<TraceMethod>   _methods;

        public TraceThread(int id, TraceMethod threadMain)
        {
            _id         = id;
            _time       = threadMain._time;
            _methods = threadMain._subs;
        }

        public TraceThread(KeyValuePair<int, TraceMethod> aggregate) 
        {  
            _id         = aggregate.Key;
            _time       = aggregate.Value._time;
            _methods = aggregate.Value._subs;
        }

        public TraceThread(int id, double time, List<TraceMethod> methods)
        {
            _id = id;
            _time = time;
            _methods = methods;
        }
    }
}
