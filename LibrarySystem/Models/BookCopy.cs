using LibrarySystem.Contracts;
using LibrarySystem.Models.Enums;

namespace LibrarySystem.Models
{
    public class BookCopy :IDisplayable ,IBorrowable
    {
        public string CopyId { get; private set; }
        public string Condition { get; private set; }
        public CopyStatus Status { get; set; }
        public Book Book { get; private set; }
        public BorrowTransaction? ActiveTransaction { get; private set; }
        public BookCopy(string copyId,Book book, string condition ="good")
        {
            CopyId = copyId;
            Book = book;
            Condition = condition;
            Status = CopyStatus.Availabe;
        }
        public string ToDisplay()
        {
            return $"Copy [{CopyId}] - {Book.Title} | Condition:{Condition} |{Status}";
        }

        public void Borrow(Member member, int loanDays = 14)
        {
            //check book copy 
            if(!IsAvailable()) throw new InvalidOperationException($"Copy:{CopyId} is not Availbale [{Status}]");// هنا المفروض نعمل حاجه اسمها Result Pattern ان اعمل حاجه لما ي succed ويعل حاجه ي failure 

            // Change status Book Copy
            Status = CopyStatus.Borrowed;
            // Create Transaction
            ActiveTransaction=new BorrowTransaction(member,this ,loanDays);
            //Add transaction to member
            member.AddTransaction(ActiveTransaction);
        }

        public decimal Return()
        {
            if (ActiveTransaction==null ) 
                throw new InvalidOperationException("No active transaction for this copy ");
            if (Status != CopyStatus.Borrowed) 
                throw new InvalidOperationException($"Copy {CopyId} is not Borrowed");
            ActiveTransaction.MarkReturned(DateOnly.FromDateTime(DateTime.Today));
            decimal fine=ActiveTransaction.CalculateFine();
            Status = CopyStatus.Availabe;
            ActiveTransaction=null;
            return fine;
        }

        public bool IsAvailable() => Status == CopyStatus.Availabe; 
    }
}