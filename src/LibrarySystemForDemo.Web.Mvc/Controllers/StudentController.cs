using Abp.Application.Services.Dto;
using LibrarySystemForDemo.Controllers;
using LibrarySystemForDemo.Departments;
using LibrarySystemForDemo.Departments.Dto;
using LibrarySystemForDemo.Students;
using LibrarySystemForDemo.Students.Dto;
using LibrarySystemForDemo.Web.Models.Students;
using Microsoft.AspNetCore.Mvc;
using System.Linq; /* <<< Don't forget to add this */
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Web.Controllers
{
    public class StudentController : LibrarySystemForDemoControllerBase
    {
        private IStudentAppService _studentAppService;
        private IDepartmentAppService _departmentAppService;

        public StudentController(IStudentAppService studentAppService, IDepartmentAppService departmentAppService)
        {
            _studentAppService = studentAppService;
            _departmentAppService = departmentAppService;
        }

        public async Task<IActionResult> Index(string searchStudents)
        {
            var students = await _studentAppService.GetAllStudentWithDepartment(new PagedStudentResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new StudentListViewModel();

            if (!string.IsNullOrEmpty(searchStudents))
            {
                model = new StudentListViewModel()
                {
                    Students = students.Items.Where(s => s.StudentName.Contains(searchStudents) || s.StudentContactNumber.Contains(searchStudents) || s.StudentEmail.Contains(searchStudents) || s.Department.Name.Contains(searchStudents)).ToList()
                };
            }
            else
            {
                model = new StudentListViewModel()
                {
                    Students = students.Items.ToList()
                };
            }

            return View(model); //model inside view
        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {

            var model = new CreateOrEditStudentViewModel();
            var modelDepartment = await _departmentAppService.GetAllAsync(new PagedDepartmentResultRequestDto { MaxResultCount = int.MaxValue });

            if (id.HasValue) //If may laman yung Id then > EDIT
            {
                var student = await _studentAppService.GetAsync(new EntityDto<int>(id.Value));
                model = new CreateOrEditStudentViewModel()
                {
                    Id = student.Id,                                        //model.Id = Id.Value;
                    StudentName = student.StudentName,                      //model.StudentName = student.StudentName;
                    StudentContactNumber = student.StudentContactNumber,
                    StudentEmail = student.StudentEmail,
                    DepartmentId = student.DepartmentId

                };
            }

            model.DepartmentList = modelDepartment.Items.ToList();
            return View(model);

        }


    }
}
