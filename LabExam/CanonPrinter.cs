using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Implements IPrinter for printing. 
    /// </summary>
    internal class CanonPrinter : Printer
    {
        public CanonPrinter(string model) : base("Canon", model) { }

        protected override void Printing(Stream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }
    }
}