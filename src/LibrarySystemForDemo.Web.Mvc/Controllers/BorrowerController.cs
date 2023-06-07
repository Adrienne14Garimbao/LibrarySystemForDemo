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
using System;
using System.Linq; /* <<< Don't forget to add this */
using System.Threading.Tasks; /* <<< Don't forget to add this too */

namespace LibrarySystemForDemo.Web.Controllers
{
    public class BorrowerController : LibrarySystemForDemoControllerBase
    {

        #region Interface Injection
        private IBorrowerAppService _borrowerAppService;

        private IBookAppService _bookAppService;
        private IStudentAppService _studentAppService;
        
        public BorrowerController(IBorrowerAppService borrowerAppService, IBookAppService bookAppService, IStudentAppService studentAppService)
        {
            _borrowerAppService = borrowerAppService;
            _bookAppService = bookAppService;
            _studentAppService = studentAppService;
        }
        #endregion 

        #region Index
        public async Task<IActionResult> Index(string searchBorrower)
        {
            #region Variable
            var model = new BorrowerListViewModel();
            var borrower = await _borrowerAppService.GetAllAsync(new PagedBorrowerResultRequestDto { MaxResultCount = int.MaxValue });
            #endregion

            #region Search
            if (!string.IsNullOrEmpty(searchBorrower))
            {
                #region If not empty
                model = new BorrowerListViewModel()
                {
                    Borrowers = borrower.Items.Where(h => h.Student.StudentName.Contains(searchBorrower) || h.Books.BookTitle.Contains(searchBorrower)   ).ToList()
                };
                #endregion
            }
            else
            {
                #region If textbox is empty
                model = new BorrowerListViewModel()
                {
                    Borrowers = borrower.Items.ToList()
                };
                #endregion
            }

            #endregion
            return View(model);
            
        }
        #endregion

        #region Create or Edit
        public async Task<IActionResult> CreateOrEdit(int? id) //DateTime dateToday
        {
            #region Variable
            var model = new CreateOrEditBorrowerListViewModel();

            var modelBook = await _bookAppService.GetAllAsync(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue });
            var modelStudent = await _studentAppService.GetAllAsync(new PagedStudentResultRequestDto { MaxResultCount = int.MaxValue });
            #endregion

            if (id.HasValue)
            {
                var borrower = await _borrowerAppService.GetAsync(new EntityDto<int>(id.Value));
                model = new CreateOrEditBorrowerListViewModel()
                {
                    Id = borrower.Id,
                    StudentId = borrower.Id,
                    BookId = borrower.Id,
                    BorrowDate = borrower.BorrowDate, //BorrowDate should be default to today's date
                    ExpectedReturnDate = borrower.ExpectedReturnDate, //ExpectedReturnDate should auto-populate 7 days after the BorrowDate
                    ReturnDate = borrower.ReturnDate
                    
                };
            }

            model.StudentList = modelStudent.Items.ToList();
            model.BookList = modelBook.Items.ToList();

            return View(model);

        }
        #endregion


    }
}
