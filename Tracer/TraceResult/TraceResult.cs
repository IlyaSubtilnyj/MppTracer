using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tracer.TraceResult
{
    public class TraceResult {

        private TraceResult? sub;
        public string Namespace { get; }
        public string Class { get; }
        public string Method { get; }
        public TimeSpan TakenTime { get; }
        public TraceResult(string @namespace, string @class, string method, TimeSpan takenTime)
        {
            Namespace = @namespace;
            Class = @class;
            Method = method;
            TakenTime = takenTime;
        }

        /// <summary>
        /// Backward compatability
        /// </summary>
        public TraceResult()
        {}

    }
}
