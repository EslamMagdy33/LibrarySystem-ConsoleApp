using ConsoleTheme;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    // to handle everything( all the outputs ) in the console => seperate the UI or the printing from my domain 
    public class DisplayServices
    {
        public void ShowBranchInfo(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("LIBRARY BRANCH INFO");
            Console.WriteLine(branch.ToDisplay()) ;
        }
        public void ShowAllUsers(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("All Regestered Users");

            IReadOnlyList<LibraryUser> users = branch.Users;
            for (int i = 0; i <users.Count; i++)
            {
                string header = users[i] is Librarian ? "Librarian Profile " : "Member Profile";
                ThemeHelper.PrintSectionTitle(header);
                Console.WriteLine(users[i].ToDisplay()); // here the run time polymoriphism will know who function will called either Librarian ToDisplay or Member ToDisplay and thats why we make the ToDisplay function int the Parents LibraryUser
            }

        }
        public void ShowAvailableCopies(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("Available Book Copies:");
            List<BookCopy> books =branch.GetAvailableCopies();
            if (books.Count == 0)
            {
                ThemeHelper.PrintWarning("No Available Book Copies Found. ");
                return;
            }
            else
            {
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine(books[i].ToDisplay());
                }
            }
        }
        public void ShowAllBookCopies(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("All Book Copies");
            if (branch.Copies.Count == 0)
            {
                ThemeHelper.PrintWarning("No Book Copies Found");
                return;
            }
            else
            {
                for (int i = 0; i < branch.Copies.Count; i++)
                {
                    Console.WriteLine(branch.Copies[i].ToDisplay());
                }
            }
        }
        public void ShowMemberHistory(Member member)
        {
            ThemeHelper.PrintSectionTitle($"Borrowing History for {member.Name}");
            Console.WriteLine(member.GetHestoryDisplay());
        }
        public void ShowBoroowSuccess(BookCopy copy, Member member)
        {
            ThemeHelper.PrintSuccess($"Copy {copy.CopyId} : {copy.Book.Title} Borrowed By {member.Name}");
            ThemeHelper.PrintSuccess($"Due Date:{copy.ActiveTransaction?.DueDate:dd/mm/yyyy}");
        }
        public void ShowReturnSucccess(BookCopy bookCopy , decimal fine)
        {
            ThemeHelper.PrintSuccess($"Copy {bookCopy.CopyId} - {bookCopy.Book.Title} Returned");
            if (fine > 0)
                ThemeHelper.PrintWarning($"Late Return Fine : {fine:f2}EGP");
            else
                ThemeHelper.PrintSuccess("Returned On Time , No Fine");
        }
        public void ShowRegisterSuccess(Member member)
        {
            ThemeHelper.PrintSuccess($"Member: {member.Name} - {member.MembershipId} Registered");
        }
        public void ShowAddCopySuccess(BookCopy bookCopy)
        {
            ThemeHelper.PrintSuccess($"Member: {bookCopy.CopyId} - {bookCopy.Book.Title} Added");

        }
    }
}
