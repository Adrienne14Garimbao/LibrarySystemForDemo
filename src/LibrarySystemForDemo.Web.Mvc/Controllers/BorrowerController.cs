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
            var getAllBorrowerWithBooksAndStudent = await _borrowerAppService.GetAllBorrowerWithBooksAndStudent(new PagedBorrowerResultRequestDto { MaxResultCount = int.MaxValue });
            
            #endregion

            #region Search
            if (!string.IsNullOrEmpty(searchBorrower))
            {
                #region If not empty
                model = new BorrowerListViewModel()
                {
                    Borrowers = getAllBorrowerWithBooksAndStudent.Items.Where(h => h.Student.StudentName.Contains(searchBorrower) || h.Books.BookTitle.Contains(searchBorrower) ).ToList()
                };
                #endregion
            }
            else
            {
                #region If textbox is empty
                model = new BorrowerListViewModel()
                {
                    Borrowers = getAllBorrowerWithBooksAndStudent.Items.ToList()
                };
                #endregion
            }

            #endregion

            return View(model);
            
        }
        #endregion

        #region Create Borrower
        public async Task<IActionResult> CreateBorrower() 
        {
            var model = new CreateOrEditBorrowerListViewModel();

            var modelStudent = await _studentAppService.GetAllAsync(new PagedStudentResultRequestDto { MaxResultCount = int.MaxValue }); 
            var modelBook = await _bookAppService.GetAllAsync(new PagedBookResultRequestDto { MaxResultCount = int.MaxValue });

            model.StudentList = modelStudent.Items.ToList(); 
            model.BookList = modelBook.Items.ToList();   

            return View(model);

        }
        #endregion

        #region Edit/Update Borrower
        public async Task<IActionResult> UpdateBorrower(int? Id)
        {

            var model = new CreateOrEditBorrowerListViewModel();
            var modelBook = await _bookAppService.GetAllBooks();
            var getStudent = await _studentAppService.GetAllStudents();

            if (Id.HasValue)
            {
                var borrower = await _borrowerAppService.GetAsync(new EntityDto<int>(Id.Value));
                model = new CreateOrEditBorrowerListViewModel()
                {
                    Id = borrower.Id,
                    StudentId = borrower.Id,
                    BookId = borrower.Id,
                    BorrowDate = borrower.BorrowDate,
                    ExpectedReturnDate = borrower.ExpectedReturnDate,
                    ReturnDate = borrower.ReturnDate,
                    //do it latwer isborrowed

                };
            }

            model.StudentList = getStudent.ToList();
            model.BookList = modelBook.ToList();

            return View(model);
        }
        #endregion


    }
}
