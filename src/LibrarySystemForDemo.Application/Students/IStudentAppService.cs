using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystemForDemo.Students.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Students
{
    public interface IStudentAppService : IAsyncCrudAppService<StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>
    {
        Task<PagedResultDto<StudentDto>> GetAllStudentWithDepartment(PagedStudentResultRequestDto input);

        Task<List<StudentDto>> GetAllStudents();

    }
}
