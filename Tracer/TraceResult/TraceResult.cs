namespace Tracer.TraceResult
{
    public class TraceResult {

        public int _id;
        public TimeSpan _time;
        public TraceMethod _methods;

        public void appendThread(int id, TraceMethod methods)
        {
            _id = id;
            _methods = methods;
            //calculate execution time by plain summation
        }

        public TraceResult()
        {
        }

    }
}
