using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tracer.Contracts;
using Trace = Tracer.TraceResult;

namespace Tracer.TraceResult
{

    public delegate Trace.TraceResult TraceFabric();

    public class TraceResultManufactory
    {

        private List<DateTime> _timeMarks = new();
        protected void MarkCall()
        {
            _timeMarks.Add(DateTime.UtcNow);
        }

        protected List<TraceFabric> _inventory = new List<TraceFabric>();
        protected void WriteData(TraceFabric oper)
        {

            _inventory.Add(oper);
        }

        public TraceResult ReadData()
        {
            List<TraceResult> products = new();
            foreach (var item in _inventory)
            {
                TraceResult traceResult = item();
                products.Add(traceResult);
            }

            return products[products.Count - 1];
            return new TraceResult();
        }

        protected void CaptureFabric()
        {

            StackTrace stackTrace = new();
            int index = _timeMarks.Count;

            TraceFabric fabric = delegate () {

                TimeSpan TakenTime = _timeMarks[index] - _timeMarks[index - 1];

                var callingFrame = stackTrace.GetFrame(3);
                var callingMethod = callingFrame?.GetMethod();
                var declaringType = callingMethod?.DeclaringType;

                var className = declaringType?.Name;
                var namespaceName = declaringType?.Namespace;

                Console.WriteLine(namespaceName + "." + className + "." + callingMethod);

                /*
                 * Parsing of stackTrace and creating of Recursive MyTraceResultStructure result
                 */

                return new TraceResult();
            };

            WriteData(fabric);
        }

        /// <summary>
        /// Be there temporary
        /// </summary>
        /// <param name="stackTrace"></param>
        /// <returns></returns>
        public static TraceResult ParseStackTrace(string stackTrace)
        {
            // Regular expression pattern to match the namespace, class, and method information
            string pattern = @"(?<=at )([^\.]+)\.([^\.]+)\.([^\.]+)";

            // Split the stack trace into individual lines
            string[] lines = stackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // Iterate through the lines and find the first line that matches the pattern
            foreach (string line in lines)
            {
                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    // Extract the namespace, class, and method from the match groups
                    string namespaceName = match.Groups[1].Value;
                    string className = match.Groups[2].Value;
                    string methodName = match.Groups[3].Value;

                    // Create and return the StackTraceInformation object
                    return new TraceResult(namespaceName, className, methodName, new TimeSpan());
                }
            }

            // If no match is found, return null or throw an exception, depending on your requirements
            return null;
        }

    }
}
