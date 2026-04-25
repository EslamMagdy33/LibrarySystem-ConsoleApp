using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibrarySystem.Models
{
    public class Librarian : LibraryUser
    {
        public string LibrarianId { get;private set; } = null! ;
        public decimal Salary { get; private set; }
        public DateOnly HireDate { get; private set; }

        public Librarian(string librarianId,string name ,decimal salary, string phone ,DateOnly hireDate) : base(name, phone)
        {
            LibrarianId = librarianId;
            Salary = salary;
            HireDate = hireDate;
        }
        public override string ToDisplay()
        {
            return $@"ID:{LibrarianId},
Name :{Name},
Phone : {Phone},
Salary :{Salary},
Hired : {HireDate}";
        }
    }
}
