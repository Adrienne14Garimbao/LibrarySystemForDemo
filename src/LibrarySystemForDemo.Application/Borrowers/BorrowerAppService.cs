using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemForDemo.Books.Dto;
using LibrarySystemForDemo.Borrowers.Dto;
using LibrarySystemForDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Borrowers
{
    public class BorrowerAppService : AsyncCrudAppService<Borrower, BorrowerDto, int, PagedBorrowerResultRequestDto, CreateBorrowerDto, BorrowerDto>, IBorrowerAppService
    {

        private readonly IRepository<Borrower, int> _repository;

        private readonly IRepository<Book, int> _bookRepository;
        private readonly IRepository<Student, int> _studentRepository;

        public BorrowerAppService(IRepository<Borrower, int> repository, IRepository<Book> bookRepository, IRepository<Student> studentRepository) : base(repository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
            _studentRepository = studentRepository;
        }

        public override Task<BorrowerDto> CreateAsync(CreateBorrowerDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<BorrowerDto>> GetAllAsync(PagedBorrowerResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<BorrowerDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        public override Task<BorrowerDto> UpdateAsync(BorrowerDto input)
        {
            return base.UpdateAsync(input);
        }

        protected override Task<Borrower> GetEntityByIdAsync(int id)
        {
            return base.GetEntityByIdAsync(id);
        }

        public async Task<PagedResultDto<BorrowerDto>> GetAllBorrowerWithBooksAndStudent(PagedBookResultRequestDto input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.Books)
                .Include(x => x.Student)
                .Select(x => ObjectMapper.Map<BorrowerDto>(x))
                .ToListAsync();

            return new PagedResultDto<BorrowerDto>(query.Count(), query);

        }


    }
}
