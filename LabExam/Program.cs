using System;
using System.Windows.Forms;

namespace LabExam
{
    class Program : IView
    {
        [STAThread]
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select your choice:");
                Console.WriteLine("1:Add new printer");
                //Нужно убрать 2 и 3 пункт и вместо них добавить пункт "печать", в котором будет выбор принтера, а затем произведётся печать. Не сразу это заметил, поэтому не успел. 
                Console.WriteLine("2:Print on Canon");
                Console.WriteLine("3:Print on Epson");
                Console.WriteLine("4:Show list of printers");
                Console.WriteLine("Ecs:Exit\n");

                var key = Console.ReadKey();

                //instead of "if-construction"
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        {
                            CreatePrinter();
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Print(new CanonPrinter());
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            Print(new EpsonPrinter());
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            PrintListOfPrinters();
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                }

                Console.WriteLine();
            }
        }

        private static void Print(Printer printer)
        {
            string fileName = "";
            if (GetFile(ref fileName))
            {
                PrinterManager.Print(printer, fileName);
            }
            else
            {
                Console.WriteLine("Wrong FileName.");
            }
        }

        private static bool GetFile(ref string fileName)
        {
            var o = new OpenFileDialog();
            o.ShowDialog();
            if (!String.IsNullOrEmpty(o.FileName))
            {
                return true;
            }

            return false;
        }

        private static void CreatePrinter()
        {
            try
            {
                Console.WriteLine("Enter printer name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter printer model");
                string model = Console.ReadLine();
                Printer printer = new Printer(name, model);

                if (PrinterManager.Add(printer))
                {
                    Console.WriteLine("Printer added.");
                }
                else
                {
                    Console.WriteLine("Printer already exists.");
                }
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("Name or Model can't be empty!");
            }
        }

        private static void PrintListOfPrinters()
        {
            if (PrinterManager.Printers.Count == 0)
            {
                Console.WriteLine("List is empty.");
            }

            foreach (Printer p in PrinterManager.Printers)
            {
                Console.WriteLine ("Name: {0}, Model: {1}.", p.Name, p.Model);
            }
        }
    }
}
