using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Contracts;

namespace Tracer.TraceResult
{
    public class TraceResultStorage
    {

        private List<PrintOperation> spans = new List<PrintOperation>();
        private IAbstractFactory factory = new TraceResultFactory();
        protected List<DateTime> timeMarks = new List<DateTime>();

        public void Add()
        {
            spans.Add(factory.CreateTraceResult(timeMarks.Count));
        }

        public TraceResult Retrieve()
        {
            return new TraceResult();
        }

        public void call()
        {

            foreach (var item in spans)
            {
                var lol = item();
            }
            //merge lols
        }

    }
}
