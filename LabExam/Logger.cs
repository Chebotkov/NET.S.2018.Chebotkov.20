using System.IO;

namespace LabExam
{
    /// <summary>
    /// implements logic of logging.
    /// </summary>
    public class Logger
    {
        public Logger()
        {
            PrinterManager.PrintEvent += PrinterManager_PrintEvent;
        }

        private void PrinterManager_PrintEvent(object sender, PrintEventArgs e)
        {
            using (StreamWriter f = new StreamWriter("log.txt", true, System.Text.Encoding.Default))
            {
                f.WriteLine(e.Message);
            }   
        }
    }
}
