using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.TraceResult
{
    public abstract class TMFConnection
    {
        /// <summary>
        /// 
        /// </summary>
        protected TraceMethodFactory _factory;

        public TMFConnection(int passedDepth)
        {
            _factory = new TraceMethodFactory(passedDepth);
        }

        protected bool _captured = false;

        abstract public void Write();
        abstract public TraceMethod Read();
    }
}
