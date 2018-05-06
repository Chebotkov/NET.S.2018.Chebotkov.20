using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam
{
    public sealed class PrinterManager
    {
        /// <summary>
        /// List of printers.
        /// </summary>
        public readonly List<Printer> Printers = new List<Printer>();

        /// <summary>
        /// Singular instance of <see cref="PrinterManager"/>
        /// </summary>
        private static PrinterManager instance;

        /// <summary>
        /// Initializes a type.
        /// </summary>
        static PrinterManager()
        {
            instance = null;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PrinterManager"/>
        /// </summary>
        private PrinterManager() { }

        /// <summary>
        /// Gets an instance of <see cref="PrinterManager"/>.
        /// </summary>
        public static PrinterManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PrinterManager();
                }

                return instance;
            }
        }

        /// <summary>
        /// Returns bool result about adding.
        /// </summary>
        /// <param name="printer">Printer.</param>
        /// <returns>True if file was added. False if file already exists.</returns>
        public bool Add(Printer printer)
        {
            if (printer == null)
            {
                return false;
            }

            if (!Printers.Contains(printer))
            {
                Printers.Add(printer);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Prints current file on specified printer.
        /// </summary>
        /// <param name="printer">Wanted printer.</param>
        /// <param name="FileName">Path to the print file.</param>
        public void Print(Printer printer, string FileName)
        {
            if (printer is null)
            {
                throw new ArgumentNullException("{0} is null.", nameof(printer));
            }

            if (FileName == null)
            {
                throw new ArgumentNullException("{0} is null.", nameof(FileName));
            }
            
            var f = File.OpenRead(FileName);
            printer.Print(f);
        }
    }
}