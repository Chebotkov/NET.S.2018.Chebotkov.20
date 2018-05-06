using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Implements logic of logging.
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Logger"/>
        /// </summary>
        public Logger(Printer printer)
        {
            printer.PrintStarted += Printer_PrintStarted;
            printer.PrintFinished += Printer_PrintFinished;
        }
        private void Printer_PrintFinished(object sender, PrintFinishedEventArgs e)
        {
            Log(String.Format("Print on {0} - {1} finished.", e.printer.Name, e.printer.Model));
        }

        private void Printer_PrintStarted(object sender, PrintStartedEventArgs e)
        {
            Log(String.Format("Print on {0} - {1} started.", e.printer.Name, e.printer.Model));
        }

        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="message">Logifiable message.</param>
        public void Log(string message)
        {
            using (StreamWriter f = new StreamWriter("log.txt", true, System.Text.Encoding.Default))
            {
                f.WriteLine(message);
            }
        }
    }
}
