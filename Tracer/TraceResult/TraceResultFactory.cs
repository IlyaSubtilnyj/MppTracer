using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Contracts;
using Trace = Tracer.TraceResult;

namespace Tracer.TraceResult
{

    class TraceResultFactory : IDelegateAbstractFactory<TraceFabric>
    {

        List<DateTime> times;

        public TraceResultFactory(List<DateTime> times)
        {
            this.times = times;
        }

        public TraceFabric CreateSnapshot()
        {

            var stackTrace = new StackTrace();
            var index = times.Count;

            TraceFabric printX = delegate () {

                TraceResult result = new TraceResult();

                TimeSpan executionTimeSpan = times.Last() - times.Last();

                var callingFrame = stackTrace.GetFrame(5);
                var callingMethod = callingFrame?.GetMethod();
                var declaringType = callingMethod?.DeclaringType;

                var className = declaringType?.Name;
                var namespaceName = declaringType?.Namespace;

                Console.WriteLine(namespaceName + "." + className + "." + callingMethod);

                /*
                 * Parsing of stackTrace and creating of Recursive MyTraceResultStructure result
                 */

                return result;
            };


            return printX;
        }

    }
}
