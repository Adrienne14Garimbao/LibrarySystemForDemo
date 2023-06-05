using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystemForDemo.Books.Dto;
using LibrarySystemForDemo.Borrowers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Borrowers
{
    public interface IBorrowerAppService : IAsyncCrudAppService<BorrowerDto, int, PagedBorrowerResultRequestDto, CreateBorrowerDto, BorrowerDto>
    {
        Task<PagedResultDto<BorrowerDto>> GetAllBorrowerWithBooksAndStudent(PagedBookResultRequestDto input);
    }
}
