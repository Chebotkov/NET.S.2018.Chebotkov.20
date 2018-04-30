using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Implements IPrinter for printing. 
    /// </summary>
    internal class CanonPrinter : Printer
    {
        public CanonPrinter()
        {
            Name = "Canon";
            Model = "123x";
        }

        public CanonPrinter(string name, string model)
        {
            Name = name;
            Model = model;
        }
    }
}