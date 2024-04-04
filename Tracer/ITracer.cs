﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace = Tracer.TraceResult;

namespace Tracer
{
    public interface ITracer
    {
        void StartTrace();

        void StopTrace();

        Trace.TraceResult GetTraceResult();
    }
}
