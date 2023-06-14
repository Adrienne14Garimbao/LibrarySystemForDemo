using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemForDemo.Entities;
using LibrarySystemForDemo.Students.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Students
{
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>, IStudentAppService
    {
        private readonly IRepository<Student, int> _repository;
        private readonly IRepository<Department> _departmentRepository;

        public StudentAppService(IRepository<Student, int> repository, IRepository<Department> departmentRepository) : base(repository)
        {
            _repository = repository;
            _departmentRepository = departmentRepository;
        }

        #region Default Generated CRUD

        public override Task<StudentDto> CreateAsync(CreateStudentDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<StudentDto>> GetAllAsync(PagedStudentResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<StudentDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<StudentDto> UpdateAsync(StudentDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Student> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }
        #endregion

        public async Task<PagedResultDto<StudentDto>> GetAllStudentWithDepartment(PagedStudentResultRequestDto input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.Department)
                .Select(x => ObjectMapper.Map<StudentDto>(x))
                .ToListAsync();

            return new PagedResultDto<StudentDto>(query.Count(), query);
        }


    }
}
