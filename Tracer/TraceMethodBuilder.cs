using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{

    public class TraceMethodBuilder
    {

        private List<TraceMethodGhost> _outputMethods = new();

        public TraceMethodBuilder() { 
            
            _outputMethods = new List<TraceMethodGhost> { new() };
        }

        public void Load()
        {

            _outputMethods.Add(new());
        }

        public void Save()
        {

            int operatingMethodIndex = _outputMethods.Count - 1;
            _outputMethods[operatingMethodIndex].finish();

            _outputMethods[operatingMethodIndex - 1].addSub(_outputMethods[operatingMethodIndex]);
            _outputMethods.RemoveAt(operatingMethodIndex);
        }

        public TraceMethod Read()
        {
            _outputMethods[0].finish();
            return _outputMethods[0].Form();
        }
    }
}
