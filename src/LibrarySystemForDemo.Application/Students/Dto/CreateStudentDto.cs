using Abp.AutoMapper;
using LibrarySystemForDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Students.Dto
{

    [AutoMapTo(typeof(Student))]
    [AutoMapFrom(typeof(Student))]

    public class CreateStudentDto
    {
        public string StudentName { get; set; }

        public string StudentContactNumber { get; set; }

        public string StudentEmail { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
