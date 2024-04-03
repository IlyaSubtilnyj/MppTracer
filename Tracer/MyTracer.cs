using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Data.SqlTypes;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tracer;

public interface IMyTracer
{
    void StartTrace();

    void StopTrace();

    MyTraceResult GetTraceResult();
}

public class MyTracer : IMyTracer
{
    private int max_depth = 0;
    private int depth = 0;

    private int Depth
    {
        get { return depth; }
        set
        {
            if (value < depth)
            {
                host.Ping(depth);
            }
            else
            {
                depth = value;
                if (depth > max_depth)
                {
                    max_depth = depth;
                }
                host.Ping();
            }
        }
    }

    private Host host = new Host();

    public void StartTrace()
    {
        Depth++;
       
    }

    public void StopTrace()
    {
        Depth--;
    }

    public MyTraceResult GetTraceResult()
    {
        Console.WriteLine("Finish methods here");
        host.call();
        return host.Retrieve();
    }

}

public delegate MyTraceResult PrintOperation();

public class TraceResultStorage
{

    private List<PrintOperation> spans = new List<PrintOperation>();

    public void Add(PrintOperation dt)
    {
        
        spans.Add(dt);
    }

    public MyTraceResult Retrieve()
    {
        return new MyTraceResult();
    }

    public void call()
    {

        foreach (var item in spans)
        {
            var lol = item();
        }
        //merge lols
    }

}

public class Host : TraceResultStorage
{

    private Stack<DateTime> timeMarks = new Stack<DateTime>();

    PrintOperation CreateTraceResult(DateTime dt)
    {
        var stackTrace = new StackTrace();
        MyTraceResult Inner()
        {
            MyTraceResult result = new MyTraceResult();
            //Thread.Sleep(2000);

            TimeSpan executionTimeSpan = DateTime.UtcNow.Subtract(dt);

            var callingFrame = stackTrace.GetFrame(4);
            var callingMethod = callingFrame?.GetMethod();
            var declaringType = callingMethod?.DeclaringType;

            var className = declaringType?.Name;
            var namespaceName = declaringType?.Namespace;

            Console.WriteLine(namespaceName+"."+className+"."+callingMethod);

            /*
             * Parsing of stackTrace and creating of Recursive MyTraceResultStructure result
             */

            return result;
        }
        return Inner;
    }

    public void Ping(int depth = 0)
    {
   
        if (depth != 0)
        {

            Add(CreateTraceResult(timeMarks.Pop()));
        }
        else
        {
            timeMarks.Push(DateTime.UtcNow);
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


public class MyTraceResult { }


public class WeakDomainTraceResult : MyTraceResult
{

    private TimeSpan span;
    public WeakDomainTraceResult(TimeSpan ts) { span = ts; }

    public override string ToString()
    {
        return span.TotalSeconds.ToString();
    }

}

public class StrongDomainTraceResult : MyTraceResult
{
    private TimeSpan span;
    public StrongDomainTraceResult(DateTime ts) { 
        span = DateTime.UtcNow.Subtract(ts);
    }

    public override string ToString()
    {
        return span.TotalSeconds.ToString();
    }
}