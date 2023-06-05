using LibrarySystemForDemo.Books.Dto;
using LibrarySystemForDemo.Entities;
using LibrarySystemForDemo.Students.Dto;
using System;
using System.Collections.Generic;

namespace LibrarySystemForDemo.Web.Models.Borrowers
{
    public class CreateOrEditBorrowerListViewModel
    {
        public int Id { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime ExpectedReturnDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int BookId { get; set; }

        public Book Books { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public List<BookDto> BookList { get; set; }

        public List<StudentDto> StudentList { get; set; }

    }
}
