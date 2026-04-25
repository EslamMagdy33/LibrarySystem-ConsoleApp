using LibrarySystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    // Abstract class to share code btw subclasses ( Member and Librarian )
    public abstract class LibraryUser :IDisplayable
    {
        public string Name { get; protected set; }
        public string Phone { get; protected set; }

        protected LibraryUser(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        public abstract string ToDisplay();// the 2 classes will diplsy depend on their behavior so its abstract method 
    }
}
