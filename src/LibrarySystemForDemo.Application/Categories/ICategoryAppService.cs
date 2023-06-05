using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystemForDemo.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Categories
{
    public interface ICategoryAppService : IAsyncCrudAppService<CategoryDto, int, PagedCategoryResultRequestDto, CreateCategoryDto, CategoryDto>
    {
        Task<PagedResultDto<CategoryDto>> GetAllCategoryWithDepartment(PagedCategoryResultRequestDto input);

    }
}
