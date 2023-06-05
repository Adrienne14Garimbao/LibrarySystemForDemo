using Abp.Application.Services.Dto;
using Abp.AutoMapper;
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

    public class CreateCategoryDto : EntityDto<int>
    {
        public string CategoryName { get; set; }

        public int DepartmentId { get; set; }

        public Department DepartmentName { get; set; }

    }
}
