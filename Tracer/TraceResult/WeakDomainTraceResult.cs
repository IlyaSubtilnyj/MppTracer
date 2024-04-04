using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.TraceResult
{
    public class WeakDomainTraceResult : TraceResult
    {

        private TimeSpan span;
        public WeakDomainTraceResult(TimeSpan ts) { span = ts; }

        public override string ToString()
        {
            return span.TotalSeconds.ToString();
        }

    }
}
