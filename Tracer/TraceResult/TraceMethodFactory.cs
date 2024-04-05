using System.Diagnostics;
using System.Text.RegularExpressions;
using Trace = Tracer.TraceResult;

namespace Tracer.TraceResult
{

    public delegate Trace.TraceMethod Fabric();

    public class TraceMethodFactory
    {
        private readonly int _passageDepth;
        private readonly int _innerPassageDepth = 2;
        public TraceMethodFactory(int passagaDepth) { 

            _passageDepth = passagaDepth + _innerPassageDepth;
        }

        private List<DateTime> _timeMarks = new();
        public void CaptureFabric()
        {
            _timeMarks.Add(DateTime.UtcNow);
        }

        protected List<Fabric> _inventory = new List<Fabric>();
        public void WriteData(Fabric oper)
        {

            _inventory.Add(oper);
        }

        public TraceMethod ReadData()
        {
            List<TraceMethod> products = new();
            foreach (var item in _inventory)
            {
                var traceMethod = item();
                products.Add(traceMethod);
            }

            return products[products.Count - 1]; //<!----
        }

        public void Fabric()
        {

            StackTrace stackTrace = new();
            int index = _timeMarks.Count;

            Fabric fabric = delegate () {

                TimeSpan TakenTime = _timeMarks[index - 1] - _timeMarks[index - 2];

                var callingFrame = stackTrace.GetFrame(_passageDepth);
                var callingMethod = callingFrame?.GetMethod();
                var declaringType = callingMethod?.DeclaringType;

                var className = declaringType?.Name;
                var namespaceName = declaringType?.Namespace;

                Console.WriteLine(namespaceName + "." + className + "." + callingMethod);

                /*
                 * Parsing of stackTrace and creating of Recursive MyTraceResultStructure result
                 */

                return new TraceMethod("", "", new TimeSpan()); //<!-----
            };

            WriteData(fabric);
        }

        /// <summary>
        /// Be there temporary
        /// </summary>
        /// <param name="stackTrace"></param>
        /// <returns></returns>
        public static TraceMethod ParseStackTrace(string stackTrace)
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
                    return new TraceMethod(methodName, className, new TimeSpan());
                }
            }

            // If no match is found, return null or throw an exception, depending on your requirements
            return null;
        }

    }
}
