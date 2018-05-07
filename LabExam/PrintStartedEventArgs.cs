using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public class PrintStartedEventArgs : EventArgs
    {
        public PrintStartedEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
