using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Tracer.Contracts;

namespace Tracer.TraceResult
{
    public class ExtrusiveHost : TraceResultStorage
    {

        private bool captured = false;

        public void Ping(int depth = 0)
        {

            if (depth == 0)
            {

                Seize();
            } else
            {

                Release();
            }
        }

        protected void Seize() {

            timeMarks.Add(DateTime.UtcNow);
            captured = false;
        }

        protected void Release()
        {
            if (!captured) {

                Add();
                captured = true;
            }

        }

        public class StackTraceInformation
        {
            public string Namespace { get; }
            public string Class { get; }
            public string Method { get; }

            public StackTraceInformation(string @namespace, string @class, string method)
            {
                Namespace = @namespace;
                Class = @class;
                Method = method;
            }
        }

        public static StackTraceInformation ParseStackTrace(string stackTrace)
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
                    return new StackTraceInformation(namespaceName, className, methodName);
                }
            }

            // If no match is found, return null or throw an exception, depending on your requirements
            return null;
        }
    }
}
