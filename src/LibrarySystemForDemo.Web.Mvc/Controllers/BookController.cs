using Abp.Application.Services.Dto;
using LibrarySystemForDemo.Authors;
using LibrarySystemForDemo.Authors.Dto;
using LibrarySystemForDemo.Books;
using LibrarySystemForDemo.Books.Dto;
using LibrarySystemForDemo.Categories;
using LibrarySystemForDemo.Categories.Dto;
using LibrarySystemForDemo.Controllers;
using LibrarySystemForDemo.Web.Models.Books;
using Microsoft.AspNetCore.Mvc;
using System.Linq; /* <<< Don't forget to add this */
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Web.Controllers
{
    public class BookController : LibrarySystemForDemoControllerBase
    {

        private IBookAppService _booksAppService;
        private ICategoryAppService _categoryAppService;
        private IAuthorAppService _authorAppService;

        public BookController(IBookAppService booksAppService, ICategoryAppService categoryAppService, IAuthorAppService authorAppService)
        {
            _booksAppService = booksAppService;
            _categoryAppService = categoryAppService;
            _authorAppService = authorAppService;
        }
        public async Task<IActionResult> Index(string searchBooks)
        {

            var books = await _booksAppService.GetAllBookWithCategory(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new BooksListViewModel();     /* ^^ Edit this later*/

            if (!string.IsNullOrEmpty(searchBooks))
            {
                model = new BooksListViewModel()
                {
                    Books = books.Items.Where(b => b.BookTitle.Contains(searchBooks) || b.Author.AuthorsName.Contains(searchBooks) || b.BookPublisher.Contains(searchBooks) || b.BookCategory.CategoryName.Contains(searchBooks)).ToList()
                };
            }
            else
            {
                model = new BooksListViewModel()
                {
                    Books = books.Items.ToList()
                };

            }

            return View(model);

        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {

            var model = new CreateOrEditBookViewModel();

            var modelCategory = await _categoryAppService.GetAllAsync(new PagedCategoryResultRequestDto { MaxResultCount = int.MaxValue });
            var modelAuthor = await _authorAppService.GetAllAsync(new PagedAuthorResultRequestDto { MaxResultCount = int.MaxValue });

            if (id.HasValue) 
            {
                var book = await _booksAppService.GetAsync(new EntityDto<int>(id.Value));
                model = new CreateOrEditBookViewModel()
                {
                    Id = book.Id,
                    BookTitle = book.BookTitle,
                    AuthorId = book.Id,
                    BookPublisher = book.BookPublisher,
                    BookCategoryId = book.Id,
                };
            }

            model.AuthorList = modelAuthor.Items.ToList();
            model.CategoryList = modelCategory.Items.ToList();

            return View(model);

        }

    }
}
