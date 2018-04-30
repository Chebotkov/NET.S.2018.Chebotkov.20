using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam
{
    public class Printer
    {
        private string name;
        private string model;
        
        public Printer(string name, string model)
        {
            Name = name;
            Model = model;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("{0} is null.", nameof(value));
                }

                name = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("{0} is null.", nameof(value));
                }

                model = value;
            }
        }

        public override bool Equals(object obj)
        {
            var printer = obj as Printer;
            return printer != null &&
                   Name == printer.Name &&
                   Model == printer.Model;
        }

        public override int GetHashCode()
        {
            var hashCode = -1566092560;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            return hashCode;
        }

        public virtual void Print(FileStream fs)
        {
            //For disposing.
            using (fs)
            {
                for (int i = 0; i < fs.Length; i++)
                {
                    // simulate printing
                    Console.WriteLine(fs.ReadByte());
                }
            }
        }
    }
}