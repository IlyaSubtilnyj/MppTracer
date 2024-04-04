using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Contracts;

namespace Tracer.TraceResult
{

    class TraceResultFactory : IAbstractFactory
    {
        public PrintOperation CreateTraceResult(int link)
        {

            return lCreateTraceResult(link);
        }

        PrintOperation lCreateTraceResult(int link)
        {
            var stackTrace = new StackTrace();
            TraceResult Inner()
            {
                TraceResult result = new TraceResult();
                //Thread.Sleep(2000);

                TimeSpan executionTimeSpan = DateTime.UtcNow.Subtract(DateTime.UtcNow);

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
            }
            return Inner;
        }

    }
}
