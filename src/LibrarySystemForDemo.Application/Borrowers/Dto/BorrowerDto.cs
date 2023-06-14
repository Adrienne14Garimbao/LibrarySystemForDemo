using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystemForDemo.Books.Dto;
using LibrarySystemForDemo.Entities;
using LibrarySystemForDemo.Students.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Borrowers.Dto
{
    #region Mapping
    [AutoMapFrom(typeof(Borrower))]
    [AutoMapTo(typeof(Borrower))]
    #endregion 

    public class BorrowerDto : EntityDto<int>
    {
        public DateTime BorrowDate { get; set; }

        public DateTime ExpectedReturnDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int? BookId { get; set; }

        public BookDto Books { get; set; }

        public int? StudentId { get; set; }

        public StudentDto Student { get; set; }

    }
}
