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
using Trace = Tracer.TraceResult;

namespace Tracer;

public class Tracer : ITracer
{

    private int depth = 0;

    private Trace.ExtrusiveHost host = new Trace.ExtrusiveHost();

    public void StartTrace()
    {
        host.Ping();
        depth++;
    }

    public void StopTrace()
    {
        host.Ping(depth);
        depth--;
    }

    public Trace.TraceResult GetTraceResult()
    {
        Console.WriteLine("Finish methods here");
        host.call();
        return host.Retrieve();
    }

}