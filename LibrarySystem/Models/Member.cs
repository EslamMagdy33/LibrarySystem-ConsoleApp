using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Member :LibraryUser
    {
        public string MembershipId { get; private set; } = null!;
        public string? Email { get; private set; }
        public DateOnly? MembershipDate { get; private set; }
        public DateOnly? DateOfBirth { get; private set; }

        private readonly List<BorrowTransaction> _transactions =new() ;
        public IReadOnlyList<BorrowTransaction> Transactions => _transactions ;

        private static int _counter = 1;
        public Member(string name, string? email, DateOnly? membershipDate, string phone, DateOnly? dateOfBirth) : base(name, phone)
        {
            MembershipId = $"MEM-{_counter++:D3}";
            Email = email;
            MembershipDate = membershipDate;
            DateOfBirth = dateOfBirth;
        }
        public Member(string name, string phone):this(name, null, null, phone, DateOnly.FromDateTime(DateTime.Today))
        {
            
        }
        // Add Transaction
        public void AddTransaction(BorrowTransaction transaction)
        {
            _transactions.Add(transaction);
        }

        // Display the transaction

        public string GetHestoryDisplay()
        {
            if (Transactions.Count == 0)
                return "No Transaction Found";
            //string result= string.Empty;=====> string is immutable type meaning he acts as a value type so each time you make += there will a new object so
            StringBuilder result = new(); // safe the memory

            for (int i = 0; i < Transactions.Count; i++)
            {
                result.Append(Transactions[i].ToDisplay());
            }
            return result.ToString() ; // finally will turn into tostring again
        }
        public override string ToDisplay() => $@"Id:{MembershipId},
Name:{Name},
Phone:{Phone},
Email:{Email?? "N/A"},
Joined:{MembershipDate},
Borrows:{Transactions.Count}";
    }
}
