using Trace = Tracer.TraceResult;

namespace ConsoleApp2;

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

        Thread thread2 = new(M2);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Trace.TraceResult traceResult = Tracer.GetTraceResult();
        Console.WriteLine(traceResult);

    }
}