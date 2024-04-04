using System.Diagnostics;
using Trace = Tracer.TraceResult;

namespace ConsoleApp2;

class Program
{

    private static readonly Tracer.Tracer Tracer = new();

    private static void M2()
    {
        Tracer.StartTrace();

        Thread.Sleep(1000);

        Tracer.StopTrace();
    }

    private static void M1()
    {
        Tracer.StartTrace();

        Thread.Sleep(1000);
        M2(); 

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