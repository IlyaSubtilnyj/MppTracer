using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Tracer.Contracts;

namespace Tracer.TraceResult
{
    public class ExtrusiveHost : TraceResultManufactory
    {

        private bool _captured = false;

        public void Seize()
        {

            if (!_captured)
            {
                _captured = true;
                CaptureFabric();
            }
            MarkCall();
        }

        public void Release()
        {

            _captured = false;
            MarkCall();
        }
    }

}
