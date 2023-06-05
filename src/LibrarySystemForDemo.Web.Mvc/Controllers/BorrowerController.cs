using Abp.Application.Services.Dto;
using LibrarySystemForDemo.Authors.Dto;
using LibrarySystemForDemo.Books;
using LibrarySystemForDemo.Books.Dto;
using LibrarySystemForDemo.Borrowers;
using LibrarySystemForDemo.Borrowers.Dto;
using LibrarySystemForDemo.Categories.Dto;
using LibrarySystemForDemo.Controllers;
using LibrarySystemForDemo.Students;
using LibrarySystemForDemo.Students.Dto;
using LibrarySystemForDemo.Web.Models.Books;
using LibrarySystemForDemo.Web.Models.Borrowers;
using Microsoft.AspNetCore.Mvc;
using System.Linq; /* <<< Don't forget to add this */
using System.Threading.Tasks; /* <<< Don't forget to add this too */

namespace LibrarySystemForDemo.Web.Controllers
{
    public class BorrowerController : LibrarySystemForDemoControllerBase
    {
        private IBorrowerAppService _borrowerAppService;

        private IBookAppService _bookAppService;
        private IStudentAppService _studentAppService;

        public BorrowerController(IBorrowerAppService borrowerAppService, IBookAppService bookAppService, IStudentAppService studentAppService)
        {
            _borrowerAppService = borrowerAppService;
            _bookAppService = bookAppService;
            _studentAppService = studentAppService;
        }

        public async Task<IActionResult> Index(string searchBorrower)
        {
            var model = new BorrowerListViewModel();

            var borrower = await _borrowerAppService.GetAllAsync(new PagedBorrowerResultRequestDto { MaxResultCount = int.MaxValue });

            if (!string.IsNullOrEmpty(searchBorrower))
            {
                model = new BorrowerListViewModel()
                {
                    Borrowers = borrower.Items.Where(h => h.Student.StudentName.Contains(searchBorrower) || h.Books.BookTitle.Contains(searchBorrower)   ).ToList()
                };
            }
            else
            {
                model = new BorrowerListViewModel()
                {
                    Borrowers = borrower.Items.ToList()
                };
            }

            return View(model);

        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {

            var model = new CreateOrEditBorrowerListViewModel();

            var modelBook = await _bookAppService.GetAllAsync(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue });
            var modelStudent = await _studentAppService.GetAllAsync(new PagedStudentResultRequestDto { MaxResultCount = int.MaxValue });
            

            if (id.HasValue)
            {
                var borrower = await _borrowerAppService.GetAsync(new EntityDto<int>(id.Value));
                model = new CreateOrEditBorrowerListViewModel()
                {
                    Id = borrower.Id,
                    StudentId = borrower.Id,
                    BookId = borrower.Id,
                    BorrowDate = borrower.BorrowDate,
                    ExpectedReturnDate = borrower.ExpectedReturnDate,
                    ReturnDate = borrower.ReturnDate
                    
                };
            }

            model.StudentList = modelStudent.Items.ToList();
            model.BookList = modelBook.Items.ToList();

            return View(model);

        }


    }
}
