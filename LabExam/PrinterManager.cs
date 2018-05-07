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
        public static ILogger logger;

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
                    logger = new Logger();
                }

                return instance;
            }
        }


        /// <summary>
        /// Gets or sets an instance of <see cref="ILogger"/>.
        /// </summary>
        public static ILogger Logger
        {
            get
            {
                return logger;
            }

            set
            {
                logger = value ?? throw new ArgumentNullException("{0} is null", nameof(value));
            }
        }

        /// <summary>
        /// Returns bool result about adding.
        /// </summary>
        /// <param name="printer">Printer.</param>
        /// <returns>True if file was added. False if file already exists.</returns>
        public void Add(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException("{0} is null.", nameof(printer));
            }

            if (!Printers.Contains(printer))
            {
                Printers.Add(printer);
            }
            else
            {
                throw new InvalidOperationException("Item already exists.");
            }
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

            printer.PrintStarted += Printer_PrintStarted;
            printer.PrintFinished += Printer_PrintFinished;
            
            var f = File.OpenRead(FileName);
            printer.Print(f);
        }

        /// <summary>
        /// Appears when printing is over.
        /// </summary>
        /// <param name="sender">Event publisher.</param>
        /// <param name="e">PrintFinishedEventArgs class.</param>
        private void Printer_PrintFinished(object sender, PrintFinishedEventArgs e)
        {
            Printer printer = sender as Printer;
            if (printer != null)
            {
                logger.Log(String.Format("Print on {0} - {1} finished", printer.Name, printer.Model));
            }
        }


        /// <summary>
        /// Appears when printing started.
        /// </summary>
        /// <param name="sender">Event publisher.</param>
        /// <param name="e">PrintStartedEventArgs class.</param>
        private void Printer_PrintStarted(object sender, PrintStartedEventArgs e)
        {
            Printer printer = sender as Printer;
            if (printer != null)
            {
                logger.Log(String.Format("Print on {0} - {1} started", printer.Name, printer.Model));
            }
        }
    }
}