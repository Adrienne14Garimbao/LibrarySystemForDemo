using LibrarySystemForDemo.Departments.Dto;
using LibrarySystemForDemo.Entities;
using System.Collections.Generic;

namespace LibrarySystemForDemo.Web.Models.Categories
{
    public class CreateOrEditCategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public int DepartmentId { get; set; }

        public Department DepartmentName { get; set; }

        public List<DepartmentDto> DepartmentList { get; set; }
    }
}
