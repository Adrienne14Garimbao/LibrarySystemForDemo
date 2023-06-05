using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibrarySystemForDemo.Books.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibrarySystemForDemo.Books
{
    public interface IBookAppService : IAsyncCrudAppService<BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>
    {
        Task<PagedResultDto<BookDto>> GetAllBookWithCategory(PagedBookResultRequestDto input);
    }
}
