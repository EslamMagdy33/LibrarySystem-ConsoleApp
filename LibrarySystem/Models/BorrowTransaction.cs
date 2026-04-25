using LibrarySystem.Contracts;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class BorrowTransaction : IDisplayable
    {
        private const string _dateFormat = "dd/MM/yyyy";
        private static int _counter = 1000;
        private const decimal _finePerDay = 10m;
        public int TransactionId { get; private set; }
        public DateOnly BorrowDate { get; private set; }
        public DateOnly DueDate { get; private set; }
        public DateOnly? ReturnDate { get; private set; }
        public Member Member { get;private set; }
        public BookCopy BookCopy { get; private set; }

        public BorrowTransaction(Member member, BookCopy bookCopy, int loanDays)
        {
            TransactionId = ++_counter;
            Member = member;
            BookCopy = bookCopy;
            BorrowDate = DateOnly.FromDateTime(DateTime.Today);
            DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(loanDays));
            ReturnDate = null;
        }

        public bool IsReturned() => ReturnDate.HasValue;
        public decimal CalculateFine()
        {
            DateOnly effDate = ReturnDate ?? DateOnly.FromDateTime(DateTime.Today); // بشوف هو رجع الكتاب والا لا .... لو لا هاتلي اليوم بتاع النهارده 
            int overDays = effDate.DayNumber - DueDate.DayNumber; // وليكن اليوم ال 135 من السنه هنقص منه عدد الايام بتاعت السماحية بتاعتي وبكدا هكون عرفت هو اتاخر اد ايه 
            return overDays > 0 ? overDays * _finePerDay : 0;
        }
        public decimal CalculateFine(DateOnly returnDate)
        {
            int overDays = returnDate.DayNumber - DueDate.DayNumber;
            return overDays > 0 ? overDays * _finePerDay : 0;
        }
        public void MarkReturned(DateOnly returnDate) => ReturnDate = returnDate;
        
        public string ToDisplay()
        {
            string status = ReturnDate.HasValue ? "Returned " : "Active ";
            decimal fine= CalculateFine();
            string fineLine = fine > 0 ? $"{fine:f2} EGP" : "None";
            string returnInfo = ReturnDate.HasValue ? ReturnDate.Value.ToString(_dateFormat) : "Not Returned Yet";
            return $@"---------------Transaction #{TransactionId}-----------------
Book:{BookCopy.Book.Title}
Colpy Id: {BookCopy.CopyId}
Borrowed :{BorrowDate.ToString(_dateFormat)}
Due : {DueDate.ToString(_dateFormat)}
Returned :{returnInfo}
Status:{status}
Fine:{fineLine}";
        }
    }
}
