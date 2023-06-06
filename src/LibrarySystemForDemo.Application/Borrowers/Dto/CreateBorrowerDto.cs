using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystemForDemo.Entities;
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

    public class CreateBorrowerDto : EntityDto<int>
    {
        public DateTime BorrowDate { get; set; }

        public DateTime ExpectedReturnDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int? BookId { get; set; }

        public Book Books { get; set; }

        public int? StudentId { get; set; }

        public Student Student { get; set; }
    }
}
