using System.Diagnostics;
using System.Text.RegularExpressions;
using Trace = Tracer.TraceResult;

namespace ConsoleApp2;

/*
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
*/

class Program
{

    private static readonly Tracer.Tracer Tracer = new();

    private static void M2()
    {
        Tracer.StartTrace();

        Thread.Sleep(500);

        Tracer.StopTrace();
    }

    private static void M1()
    {
        Tracer.StartTrace();

        Thread.Sleep(1000);
        M2();
        //M2();

        Tracer.StopTrace();
    }

    public static void Main(string[] args)
    {
        
        Thread thread1 = new(M1);
        thread1.Start();
        thread1.Join();

        Trace.TraceResult traceResult = Tracer.GetTraceResult();
        Console.WriteLine(traceResult);

    }
}