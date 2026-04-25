using LibrarySystem.Contracts;
using LibrarySystem.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class LibraryBranch :IDisplayable
    {
        public string BranchId { get; private set; }
        public string BranchName { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string OpeningHours { get; private set; }
        public Librarian Manager { get; set; }
        private readonly List<BookCopy> _copies = new();
        private readonly List<Member> _members = new();
        public IReadOnlyList<BookCopy> Copies => _copies;
        public IReadOnlyList<Member> Members => _members;

        //to get the users 
        public IReadOnlyList<LibraryUser> Users
        {
            get
            {
                List<LibraryUser> users = new();
                users.Add(Manager);// عندي مدير واحد للفرع
                users.AddRange(Members);// عندي موظفين كتيير 
                return users;
            }
        }

        public LibraryBranch(string branchId, string branchName, string address, string phone, string openingHours, Librarian manager)
        {
            BranchId = branchId;
            BranchName = branchName;
            Address = address;
            Phone = phone;
            OpeningHours = openingHours;
            Manager = manager;
        }

        public Member RegisterMember(string name, string phone)
        {
            var Member = new Member(name, phone);
            _members.Add(Member);
            return Member;
        }
        public Member RegisterMember(string name,DateOnly? dateOfBirth, string email ,string phone , DateOnly membershipDate)
        {
            var Member = new Member(name,email,membershipDate,phone, dateOfBirth);
            _members.Add(Member);
            return Member;
        }

        public Member FindMember(string membershipId)
        {
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].MembershipId==membershipId.NormalizeID())
                    return _members[i];
            }
            throw new InvalidOperationException("Member Not Found");

        }
        public BookCopy FindCopy(string copyId)
        {
            for (int i = 0; i < _copies.Count; i++)
            {
                if (_copies[i].CopyId == copyId.NormalizeID())
                    return _copies[i];
            }
            throw new InvalidOperationException("Book Copy Not Found");

        }
        public void AddBookCopy(BookCopy book)
        {
            _copies.Add(book);
        }
        public List<BookCopy> GetAvailableCopies()
        {
            List<BookCopy> availableCopy = new();
            for (int i = 0; i < _copies.Count; i++)
            {
                if (_copies[i].IsAvailable())
                    availableCopy.Add(_copies[i]);
            }
            return availableCopy;
        }

        public string ToDisplay()=>$@"BranchId:{BranchId},
Name:{BranchName},
Address:{Address}
Phone:{Phone},
Opening Hours:{OpeningHours},
Manager:{Manager.Name},
Total Members:{_members.Count},
Total Book Copies :{_copies.Count}";
    }
}
