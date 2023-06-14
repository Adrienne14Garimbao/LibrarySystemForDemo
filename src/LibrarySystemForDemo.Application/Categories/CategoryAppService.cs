using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemForDemo.Categories.Dto;
using LibrarySystemForDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Categories
{
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, int, PagedCategoryResultRequestDto, CreateCategoryDto, CategoryDto>, ICategoryAppService
    {
        private readonly IRepository<Category, int> _repository;
        private readonly IRepository<Department> _departmentRepository;

        public CategoryAppService(IRepository<Category, int> repository, IRepository<Department> departmentRepository) : base(repository)
        {
            _repository = repository;
            _departmentRepository = departmentRepository;
        }

        #region Default Generated CRUD
        public override Task<CategoryDto> CreateAsync(CreateCategoryDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<CategoryDto>> GetAllAsync(PagedCategoryResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<CategoryDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<CategoryDto> UpdateAsync(CategoryDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Category> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }
        #endregion

        public async Task<PagedResultDto<CategoryDto>> GetAllCategoryWithDepartment(PagedCategoryResultRequestDto input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.DepartmentName)
                .Select(x => ObjectMapper.Map<CategoryDto>(x))
                .ToListAsync();

            return new PagedResultDto<CategoryDto>(query.Count(), query);
        }

    }
}
