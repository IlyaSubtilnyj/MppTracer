using System.Diagnostics;
using Tracer;

namespace ConsoleApp2;

class Program
{

    private static readonly MyTracer Tracer = new();

    private static void M2()
    {
        Tracer.StartTrace();

        Thread.Sleep(2000);

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
        
        Thread thread1 = new(M2);
        thread1.Start();
        thread1.Join();

        MyTraceResult traceResult = Tracer.GetTraceResult();
        Console.WriteLine(traceResult);

    }
}