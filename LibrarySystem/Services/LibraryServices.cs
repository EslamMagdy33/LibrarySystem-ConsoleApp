using ConsoleTheme;
using LibrarySystem.Extensions;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public class LibraryServices
    {
        private readonly LibraryBranch _branch;
        private readonly DisplayServices _displayServices;

        public LibraryServices(LibraryBranch libraryBranch, DisplayServices displayServices)
        {
            _branch = libraryBranch;
            _displayServices = displayServices;
        }

        // 1- handle Borrow 2- handle Retirn  3- Handle History  4- handle Register Member
        public void HandleBorrow()
        {
            string memberId = ThemeHelper.Prompt("Member Id:").NormalizeID();
            Member member= _branch.FindMember(memberId);
            _displayServices.ShowAvailableCopies(_branch);
            string copuId = ThemeHelper.Prompt("Copy Id to Borrow :").NormalizeID();
            BookCopy bookCopy=_branch.FindCopy(copuId);
            bookCopy.Borrow(member);
            _displayServices.ShowBoroowSuccess(bookCopy, member);

        }
        public void HandleReturn()
        {
            string copyId = ThemeHelper.Prompt("Copy Id to return ").NormalizeID();
            BookCopy copy= _branch.FindCopy(copyId);
            decimal fine = copy.Return();
            _displayServices.ShowReturnSucccess(copy, fine);

        }
        public void HandleHistory()
        {
            string memberId = ThemeHelper.Prompt("Member Id");
            Member member= _branch.FindMember(memberId);
            _displayServices.ShowMemberHistory(member);

        }
        public void HandleRegisterMember()
        {
            string name = ThemeHelper.Prompt("Full Name:");
            string phone = ThemeHelper.Prompt("Phone Number");
            if (!phone.IsPhoneValid())
                throw new InvalidOperationException("Phone Number is Not valid");
            string email = ThemeHelper.Prompt("Email");
            if (!email.IsEmailValid())
                throw new InvalidOperationException("Email is Not Valid");
           Member member=_branch.RegisterMember(name, null, email, phone, DateOnly.FromDateTime(DateTime.Today));
            _displayServices.ShowRegisterSuccess(member);
        }


    }
}
