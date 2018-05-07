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
        public Logger()
        {
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
