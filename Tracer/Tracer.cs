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
using Tracer.Contracts;
using Tracer.TraceResult;

namespace Tracer;

public class Tracer : ITracer
{

    private Trace.ExtrusiveHost host = new Trace.ExtrusiveHost();

    public void StartTrace()
    {
        host.Release();
    }

    public void StopTrace()
    {
        host.Seize();
    }

    public Trace.TraceResult GetTraceResult()
    {
       
        return host.ReadData();
    }

}