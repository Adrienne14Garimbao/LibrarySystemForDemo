using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemForDemo.Books.Dto;
using LibrarySystemForDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibrarySystemForDemo.Books
{
    public class BookAppService : AsyncCrudAppService<Book, BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>, IBookAppService
    {
        private readonly IRepository<Book, int> _repository;
        private readonly IRepository<Category> _categoryRepository;

        private readonly IRepository<Author> _authorRepository;

        public BookAppService(IRepository<Book, int> repository, IRepository<Category> categoryRepository, IRepository<Author> authorRepository) : base(repository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
        }

        #region Default Generated CRUD
        public override Task<BookDto> CreateAsync(CreateBookDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<BookDto>> GetAllAsync(PagedBookResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<BookDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BookDto> UpdateAsync(BookDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Book> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }
        #endregion

        public async Task<PagedResultDto<BookDto>> GetAllBookWithCategory(PagedBookResultRequestDto input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.BookCategory)
                .Include(x => x.Author)
                .Select(x => ObjectMapper.Map<BookDto>(x))
                .ToListAsync();

            return new PagedResultDto<BookDto>(query.Count(), query);

        }
    }
}
