using LibrarySystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Book:IDisplayable
    {
        public string ISBN { get; private set; }
        public string Title { get; private set; }
        public string AutherName { get; private set; }
        public string Category { get; private set; }
        public int PublicationYear { get;  set; }
        public Book(string iSPN, string title, string autherName, string category, int publicationYear)
        {
            ISBN = iSPN;
            Title = title;
            AutherName = autherName;
            Category = category;
            PublicationYear = publicationYear;
        }
        public Book(string isbn ,string title):this(isbn,title,"Unkown","General",0)
        {
            
        }

        public string ToDisplay() => $"[{ISBN}] \"{Title}\" by {AutherName} ({ PublicationYear}) -{Category}";
         
    }
}
