using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Tracer.Exceptions;

namespace Tracer
{
    public class Tracer : ITracer
    {
        private ConcurrentDictionary<int, TraceMethodBuilder> _threadsBuilders = new();

        public void StartTrace()
        {

            Host().Load();
        }

        public void StopTrace()
        {

            Host().Save();
        }

        public TraceResult GetTraceResult()
        {

            List<TraceThread> threads = new();

            foreach (var aggregate in _threadsBuilders)
            {

                threads.Add(new(aggregate.Key, aggregate.Value.Read()));
            }

            return new(threads);
        }

        private TraceMethodBuilder Host([CallerMemberName] string method = "")
        {

            int threadId = Thread.CurrentThread.ManagedThreadId;
            TraceMethodBuilder? host = null;

            if (method.Equals("StartTrace"))
            {

                if (!_threadsBuilders.TryGetValue(threadId, out host))
                {

                    host = new TraceMethodBuilder();
                    _threadsBuilders[threadId] = host;
                }
            }
            else
            {

                if (!_threadsBuilders.TryGetValue(threadId, out host))
                {

                    throw new LogicalException($"Not exists. Called from {method}");
                }
            }

            return host;
        }

    }
}

