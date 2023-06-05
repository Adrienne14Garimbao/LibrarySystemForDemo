using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibrarySystemForDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Authors.Dto
{

    [AutoMapTo(typeof(Author))]
    [AutoMapFrom(typeof(Author))]
    public class CreateAuthorDto : EntityDto<int>
    {
        public string AuthorsName { get; set; }

    }
}
