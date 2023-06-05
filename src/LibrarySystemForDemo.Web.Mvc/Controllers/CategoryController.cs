using Abp.Application.Services.Dto;
using LibrarySystemForDemo.Categories;
using LibrarySystemForDemo.Categories.Dto;
using LibrarySystemForDemo.Controllers;
using LibrarySystemForDemo.Departments;
using LibrarySystemForDemo.Departments.Dto;
using LibrarySystemForDemo.Web.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using System.Linq; /* <<< Don't forget to add this */
using System.Threading.Tasks; /* <<< Don't forget to add this too */

namespace LibrarySystemForDemo.Web.Controllers
{
    public class CategoryController : LibrarySystemForDemoControllerBase
    {

        private IDepartmentAppService _departmentAppService;
        private ICategoryAppService _categoryAppService;

        public CategoryController(IDepartmentAppService departmentAppService, ICategoryAppService categoryAppService)
        {
            _departmentAppService = departmentAppService;
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index(string searchCategory)
        {
            var category = await _categoryAppService.GetAllCategoryWithDepartment(new PagedCategoryResultRequestDto { MaxResultCount = int.MaxValue });
            var model = new CategoryListViewModel();

            if (!string.IsNullOrEmpty(searchCategory))
            {
                model = new CategoryListViewModel()
                {
                    Categories = category.Items.Where(c => c.CategoryName.Contains(searchCategory) || c.DepartmentName.Name.Contains(searchCategory)).ToList()
                };
            }
            else
            {
                model = new CategoryListViewModel()
                {
                    Categories = category.Items.ToList()
                };
            }

            return View(model);
        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {
            var model = new CreateOrEditCategoryViewModel();
            var modelDepartment = await _departmentAppService.GetAllAsync(new PagedDepartmentResultRequestDto { MaxResultCount = int.MaxValue });


            if (id.HasValue) //If may laman yung Id then > EDIT
            {
                var category = await _categoryAppService.GetAsync(new EntityDto<int>(id.Value));
                model = new CreateOrEditCategoryViewModel()
                {
                    Id = category.Id,                                        //model.Id = category.Id;
                    CategoryName = category.CategoryName,                    //model.CategoryName = category.CategoryName;
                    DepartmentId = category.DepartmentId
                };
            }

            model.DepartmentList = modelDepartment.Items.ToList();
            return View(model);

        }

    }
}
