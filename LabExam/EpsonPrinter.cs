using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Implements IPrinter for printing. 
    /// </summary>
    internal class EpsonPrinter : Printer
    {
        public EpsonPrinter()
        {
            Model = "231";
            Name = "Epson";
        }

        public EpsonPrinter(string name, string model)
        {
            Name = name;
            Model = model;
        }
    }
}