using System.Net;
using System.Xml.Linq;

namespace Tracer
{
    public class TraceMethod
    {

        public readonly string              _method;
        public readonly string              _class;
        public readonly int                 _time;
        public readonly List<TraceMethod>   _subs;
        
        public TraceMethod(string methodName, string className, int executionTime, List<TraceMethod> submethods)
        {
            _method     = methodName;
            _class      = className;
            _time       = executionTime;
            _subs       = submethods;
        }
    }
}
