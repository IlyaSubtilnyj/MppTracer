using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Tracer.TraceResult;
using Trace = Tracer.TraceResult;

namespace Tracer;

class LogicalException : Exception
{
    public LogicalException(string message) : base(message)
    {
    }
}

public sealed class Tracer : ITracer
{
    private ConcurrentDictionary<int, Trace.TMFKeepAlive> _threadTraces = new();

    public void StartTrace()
    {
        Host().Suspend();
    }

    public void StopTrace()
    {
        Host().Send();
    }

    public Trace.TraceResult GetTraceResult()
    {
        Trace.TraceResult result = new Trace.TraceResult();

        foreach (KeyValuePair<int, TMFKeepAlive> pair in _threadTraces)
        {

            result.appendThread(pair.Key, pair.Value.Read());
        }
       
        return result;//<!------_threadTraces.Last().Value.Read();
    }

    private Trace.TMFKeepAlive Host([CallerMemberName] string method = "")
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;
        Trace.TMFKeepAlive? host = null;

        if (method.Equals("StartTrace"))
        {
            if (!_threadTraces.TryGetValue(threadId, out host))
            {
                host = new Trace.TMFKeepAlive();
                _threadTraces[threadId] = host;
            }
        }
        else
        {
            if (!_threadTraces.TryGetValue(threadId, out host))
            {
                throw new LogicalException($"Not exists. Called from {method}");
            }
        }

        return host;
    }

}