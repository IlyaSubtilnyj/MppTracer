using Tracer;
using Tracer.Serialization;
using Tracer.Serialization.Json;
using Tracer.Serialization.Xml;
using Tracer.workspace.output;

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

        M2();
        Thread.Sleep(500);
        
        //thread.Join();
        Tracer.StopTrace();
    }

    private static void M()
    {
        M2();
    }

    public static void Main(string[] args)
    {

        Thread thread1 = new(M1);
        Thread thread2 = new(M2);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        TraceResult traceResult = Tracer.GetTraceResult();

        IWriter cwriter = new ConsoleWriter();
        IWriter fwriter = new FileWriter("lol.txt");
        ITraceResultSerializer serializer = new JsonSerializer();

        cwriter.Write(serializer.Serialize(traceResult));
    }
}