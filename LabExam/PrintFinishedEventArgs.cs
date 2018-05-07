using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public class PrintFinishedEventArgs
    {
        public PrintFinishedEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
