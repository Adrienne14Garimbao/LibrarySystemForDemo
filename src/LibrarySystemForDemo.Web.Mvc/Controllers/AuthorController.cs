using Abp.Application.Services.Dto;
using LibrarySystemForDemo.Authors;
using LibrarySystemForDemo.Authors.Dto;
using LibrarySystemForDemo.Controllers;
using LibrarySystemForDemo.Web.Models.Authors;
using Microsoft.AspNetCore.Mvc;
using System.Linq; /* <<< Don't forget to add this */
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Web.Controllers
{
    public class AuthorController : LibrarySystemForDemoControllerBase
    {

        private IAuthorAppService _authorAppService;

        public AuthorController(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        public async Task<IActionResult> Index(string searchAuthor)
        {

            var author = await _authorAppService.GetAllAsync(new PagedAuthorResultRequestDto { MaxResultCount = int.MaxValue });

            var model = new AuthorsListViewModel();

            if (!string.IsNullOrEmpty(searchAuthor))
            {
                model = new AuthorsListViewModel()
                {
                    Authors = author.Items.Where(a => a.AuthorsName.Contains(searchAuthor)).ToList()
                };
            }
            else
            {
                model = new AuthorsListViewModel()
                {
                    Authors = author.Items.ToList()
                };
            }

            return View(model);
        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {

            var model = new CreateOrEditAuthorListViewModel();

            if (id.HasValue) //If may laman yung Id then > EDIT
            {
                var author = await _authorAppService.GetAsync(new EntityDto<int>(id.Value));
                model = new CreateOrEditAuthorListViewModel()
                {
                    Id = author.Id,                   
                    AuthorsName = author.AuthorsName,               
                };
            }

            return View(model);

        }

    }
}
