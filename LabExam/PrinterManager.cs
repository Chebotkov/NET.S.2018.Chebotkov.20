using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    public delegate void PrinterDelegate(string arg);
    
    public static class PrinterManager
    {
        //Universal version. Instead of "Onprinted" event and "PrinterDelegate" delegate.
        public static event EventHandler<PrintEventArgs> PrintEvent;
        private static Logger logger = new Logger();

        static PrinterManager()
        {
            Printers = new List<Printer>();
        }

        public static List<Printer> Printers { get; set; }

        /// <summary>
        /// Returns bool result about adding.
        /// </summary>
        /// <param name="p1">Printer.</param>
        /// <returns>True if file was added. False if file already exists.</returns>
        public static bool Add(Printer p1)
        {
            if (!Printers.Contains(p1))
            {
                Printers.Add(p1);
                return true;
            }

            return false;
        }

        public static void Print(Printer p1, string FileName)
        {
            if (p1 is null)
            {
                throw new ArgumentNullException("{0} is null.", nameof(p1));
            }

            PrintEvent(null, new PrintEventArgs(String.Format("Print on {0} started", p1.Name)));
            var f = File.OpenRead(FileName);
            p1.Print(f);
            PrintEvent(null, new PrintEventArgs(String.Format("Print on {0} finished", p1.Name)));
        }
    }
}