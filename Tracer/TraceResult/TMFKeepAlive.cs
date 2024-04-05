namespace Tracer.TraceResult
{
    /// <summary>
    /// Bridge pattern + State pattern like for non throwing mutex(kind of remaining host).
    /// </summary>
    public sealed class TMFKeepAlive : TMFConnection
    {

        public TMFKeepAlive() : base(2) { }

        /// <summary>
        /// Suspend host sending and calculation
        /// </summary>
        public void Suspend()
        {

            _factory.CaptureFabric();
            _captured = false;
        }

        /// <summary>
        /// Send signal to host to proceed calcultaion
        /// </summary>
        public void Send() //may be need renaming
        {

            _factory.CaptureFabric();
            if (!_captured)
            {
                _captured = true;
                Write();
            }
        }

        public override void Write()
        {

            _factory.Fabric();
        }

        /// <summary>
        /// Return 
        /// </summary>
        /// <returns>???</returns>
        public override TraceMethod Read() { 
            
            return _factory.ReadData();
        }

    }

}
