using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public class PrintStartedEventArgs : EventArgs
    {
        public PrintStartedEventArgs(Printer printer)
        {
            this.printer = printer;
        }

        public Printer printer { get; private set; }
    }
}
