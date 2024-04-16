namespace Tracer
{
    public class TraceResult
    {

        public readonly List<TraceThread> _threads;

        public TraceResult(List<TraceThread> threads)
        {
                
            _threads = threads;
        }
    }
}
