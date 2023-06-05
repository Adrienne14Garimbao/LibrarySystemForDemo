using Abp.Application.Services.Dto;
using LibrarySystemForDemo.Controllers;
using LibrarySystemForDemo.Departments;
using LibrarySystemForDemo.Departments.Dto;
using LibrarySystemForDemo.Entities;
using LibrarySystemForDemo.Web.Models.Departments;
using Microsoft.AspNetCore.Mvc;
using System.Linq; /* <<< Don't forget to add this */
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Web.Controllers
{
    public class DepartmentController : LibrarySystemForDemoControllerBase
    {

        private IDepartmentAppService _departmentAppService;

        public DepartmentController(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }

        public async Task<IActionResult> Index(string searchDepartments)
        {

            var departments = await _departmentAppService.GetAllAsync(new PagedDepartmentResultRequestDto { MaxResultCount = int.MaxValue });

            var model = new DepartmentListViewModel();

            if (!string.IsNullOrEmpty(searchDepartments))
            {
                model = new DepartmentListViewModel()
                {
                    Departments = departments.Items.Where(d => d.Name.Contains(searchDepartments)).ToList()
                };
            }
            else
            {
                model = new DepartmentListViewModel()
                {
                    Departments = departments.Items.ToList()
                };

            }

            return View(model);
        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {

            var model = new CreateOrEditDepartmentViewModel();

            if (id.HasValue) //If may laman yung Id then > EDIT
            {
                var department = await _departmentAppService.GetAsync(new EntityDto<int>(id.Value));
                model = new CreateOrEditDepartmentViewModel()
                {
                    Id = department.Id,                   //model.Id = Id.Value;
                    Name = department.Name,               //model.Name = department.Name;
                };
            }

            return View(model);

        }

    }
}
