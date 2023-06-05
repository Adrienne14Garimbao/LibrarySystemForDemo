using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystemForDemo.Departments.Dto;
using LibrarySystemForDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Students.Dto
{
    [AutoMapFrom(typeof(Student))]
    [AutoMapTo(typeof(Student))]

    public class StudentDto : EntityDto<int>
    {
        public string StudentName { get; set; }

        public string StudentContactNumber { get; set; }

        public string StudentEmail { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentDto Department { get; set; }


    }
}
