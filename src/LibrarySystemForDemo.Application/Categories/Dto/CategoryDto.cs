using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystemForDemo.Departments.Dto;
using LibrarySystemForDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Categories.Dto
{
    [AutoMapFrom(typeof(Category))]
    [AutoMapTo(typeof(Category))]
    public class CategoryDto : EntityDto<int>
    {
        public string CategoryName { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentDto DepartmentName { get; set; }

    }
}
