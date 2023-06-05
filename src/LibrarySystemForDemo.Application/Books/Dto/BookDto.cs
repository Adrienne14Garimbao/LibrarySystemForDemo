using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystemForDemo.Authors.Dto;
using LibrarySystemForDemo.Categories.Dto;
using LibrarySystemForDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Books.Dto
{
    [AutoMapFrom(typeof(Book))]
    [AutoMapTo(typeof(Book))]
    public class BookDto : EntityDto<int>
    {
        public string BookTitle { get; set; }

        public string BookPublisher { get; set; }

        public bool? IsBorrowed { get; set; }

        public int? BookCategoryId { get; set; }

        public CategoryDto BookCategory { get; set; }

        public int? AuthorId { get; set; }  /* <<<< I Add this   */

        public AuthorDto Author { get; set; } /* <<<< I Add this   */

    }
}
