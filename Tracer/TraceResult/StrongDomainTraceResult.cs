using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.TraceResult
{
    public class StrongDomainTraceResult : TraceResult
    {
        private TimeSpan span;
        public StrongDomainTraceResult(DateTime ts)
        {
            span = DateTime.UtcNow.Subtract(ts);
        }

        public override string ToString()
        {
            return span.TotalSeconds.ToString();
        }
    }
}
