using Abp.Application.Services;
using LibrarySystemForDemo.Authors.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Authors
{
    public interface IAuthorAppService : IAsyncCrudAppService<AuthorDto, int, PagedAuthorResultRequestDto, CreateAuthorDto, AuthorDto>
    {


    }
}
