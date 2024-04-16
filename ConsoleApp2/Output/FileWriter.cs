using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.workspace.output
{
    public class FileWriter : IWriter
    {
        private string _fileName;

        public FileWriter(string fileName)
        {

            _fileName = fileName;
        }

        public void Write(string data)
        {

            StreamWriter streamWriter = File.CreateText(_fileName);
            streamWriter.Write(data);
            streamWriter.Close();
        }
    }
}
