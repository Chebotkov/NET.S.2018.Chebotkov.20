using System;
using System.Windows.Forms;

namespace LabExam
{
    class Program
    {
        private static PrinterManager printerManager = PrinterManager.Instance;
        [STAThread]
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Press:");
                Console.WriteLine("1:Add new printer");
                Console.WriteLine("2:Print");
                Console.WriteLine("3:Show list of printers");
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
                            if (printerManager.Printers.Count > 0)
                            {
                                Console.Clear();
                                int i = 1;
                                foreach (Printer printer in printerManager.Printers)
                                {
                                    Console.WriteLine("{0}. {1} {2}", i, printer.Name, printer.Model);
                                    i++;
                                }
                                string choise = Console.ReadLine();
                                if (Int32.TryParse(choise, out int number) && number <= printerManager.Printers.Count)
                                {
                                    Print(printerManager.Printers[number-1]);
                                }
                                else
                                {
                                    Console.WriteLine("Wrong number!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no printers");
                            }

                            break;
                        }
                    case ConsoleKey.D3:
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
                printerManager.Print(printer, fileName);
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
            string name = "RandomPrinter";
            Printer printer;

            Console.Clear();
            Console.WriteLine("Choose a model:\n1.Canon\n2.Epson\n3.Other");
            var key = Console.ReadKey();
            Console.Clear();

            try
            {
                if (key.Key == ConsoleKey.D3)
                {
                    Console.WriteLine("Enter printer name");
                    name = Console.ReadLine();
                }

                Console.WriteLine("Enter printer model");
                string model = Console.ReadLine();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        {
                            printer = new CanonPrinter(model);
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            printer = new EpsonPrinter(model);
                            break;
                        }
                    default:
                        {
                            printer = new RandomPrinter(name, model);
                            break;
                        }
                }

                if (printerManager.Add(printer))
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
            if (printerManager.Printers.Count == 0)
            {
                Console.WriteLine("List is empty.");
            }
            
            foreach (Printer p in printerManager.Printers)
            {
                Console.WriteLine ("Name: {0}, Model: {1}.", p.Name, p.Model);
            }
        }
    }
}
