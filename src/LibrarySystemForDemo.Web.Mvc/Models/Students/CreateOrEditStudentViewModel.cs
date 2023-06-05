using LibrarySystemForDemo.Departments.Dto;
using LibrarySystemForDemo.Entities;
using System.Collections.Generic;

namespace LibrarySystemForDemo.Web.Models.Students
{
    public class CreateOrEditStudentViewModel
    {
        public int Id { get; set; }

        public string StudentName { get; set; }

        public string StudentContactNumber { get; set; }

        public string StudentEmail { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public List<DepartmentDto> DepartmentList { get; set; }

    }
}
