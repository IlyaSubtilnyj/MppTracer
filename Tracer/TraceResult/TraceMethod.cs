namespace Tracer.TraceResult
{
    public class TraceMethod
    {
        public readonly string _name;
        public readonly string _class;
        public readonly TimeSpan _time;
        private TraceResult? sub;
        public TraceMethod(string name, string @class, TimeSpan time)
        {
            _name = name;
            _class = @class;
            _time = time;
        }

    }
}
