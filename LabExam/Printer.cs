﻿using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam
{
    public abstract class Printer
    {
        public event EventHandler<PrintStartedEventArgs> PrintStarted;
        public event EventHandler<PrintFinishedEventArgs> PrintFinished;
        private string name;
        private string model;
        
        /// <summary>
        /// Initializes a new instance of<see cref="Printer"/>
        /// </summary>
        /// <param name="name">Printer name.</param>
        /// <param name="model">Printer model.</param>
        public Printer(string name, string model)
        {
            Name = name ?? throw new ArgumentNullException("{ 0 } is null.", nameof(name));
            Model = model ?? throw new ArgumentNullException("{ 0 } is null.", nameof(model));
        }

        /// <summary>
        /// Gets printer name.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            }
        }

        /// <summary>
        /// Gets printer model.
        /// </summary>
        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                model = value;
            }
        }

        /// <summary>
        /// Compares current instance with specified object.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>True of two objects are equals. False - another case.</returns>
        public override bool Equals(object obj)
        {
            var printer = obj as Printer;
            return printer != null &&
                   Name == printer.Name &&
                   Model == printer.Model;
        }

        /// <summary>
        /// Calculates hashcode.
        /// </summary>
        /// <returns>Hashcode.</returns>
        public override int GetHashCode()
        {
            var hashCode = -1566092560;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            return hashCode;
        }

        /// <summary>
        /// Implements logic of printing.
        /// </summary>
        /// <param name="stream">Certain stream.</param>
        protected abstract void Printing(Stream stream);

        /// <summary>
        /// Prints something on the stream.
        /// </summary>
        /// <param name="stream">Certain stream.</param>
        public virtual void Print(Stream stream)
        {
            PrintStarted?.Invoke(this, new PrintStartedEventArgs("Print started."));
            Printing(stream);
            PrintFinished?.Invoke(this, new PrintFinishedEventArgs("Print finished"));
        }
    }
}