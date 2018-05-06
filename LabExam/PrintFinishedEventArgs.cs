using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public class PrintFinishedEventArgs
    {
        public PrintFinishedEventArgs(Printer printer)
        {
            this.printer = printer;
        }

        public Printer printer { get; private set; }
    }
}
