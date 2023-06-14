using LibrarySystemForDemo.Authors.Dto;
using LibrarySystemForDemo.Categories.Dto;
using LibrarySystemForDemo.Entities;
using System.Collections.Generic;

namespace LibrarySystemForDemo.Web.Models.Books
{
    public class CreateOrEditBookViewModel
    {
        public int Id { get; set; }

        public string BookTitle { get; set; }

        public string BookPublisher { get; set; }

        public int AuthorId { get; set; }

        public bool? IsBorrowed { get; set; }

        public Author Author { get; set; }

        public int BookCategoryId { get; set; }

        public Category Category { get; set; }

        public List<CategoryDto> CategoryList { get; set; }

        public List<AuthorDto> AuthorList { get; set; }


    }
}
