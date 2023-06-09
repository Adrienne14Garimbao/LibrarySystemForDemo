﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibrarySystemForDemo.Books;
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
        #region IRepository
        private readonly IRepository<Borrower, int> _repository;
        //private readonly IRepository<Book, int> _bookRepository;
        //private readonly IRepository<Student, int> _studentRepository;

        //public readonly IBookAppService _bookIAppService;

        #endregion

        public BorrowerAppService(IRepository<Borrower, int> repository) : base(repository)
        {
            _repository = repository;
            //_bookRepository = bookRepository;
            //_studentRepository = studentRepository;
            //_bookIAppService = bookAppService;
        }

        #region Default CRUD Override
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
        #endregion

        #region Get all Borrowers togerther with Books and Students
        public async Task<PagedResultDto<BorrowerDto>> GetAllBorrowerWithBooksAndStudent(PagedBorrowerResultRequestDto input)
        {
            var query = await _repository.GetAll()
                .Include(x => x.Books)
                .Include(x => x.Student)
                .Select(x => ObjectMapper.Map<BorrowerDto>(x))
                .ToListAsync();

            return new PagedResultDto<BorrowerDto>(query.Count(), query);

        }
        #endregion

        //public async Task<List<BorrowerDto>> GetAllBorrower()
        //{
        //    var returnquery = await _repository.GetAll().Select(x => ObjectMapper.Map<BorrowerDto>(x)).ToListAsync(); //only for the borrowers 

        //    return returnquery;
        //}

        //public async Task<BookDto> GetAllBookBorrowed(EntityDto<int> input) //create another new method to get the book isborrowed 
        //{
        //    var isBorrowed = await _bookIAppService.GetAsync(input);

        //    if (isBorrowed.IsBorrowed == true)
        //    {
        //        isBorrowed.IsBorrowed = false;
        //    }
        //    else
        //    {
        //        isBorrowed.IsBorrowed = true;
        //    }
        //    var book2 = await _bookIAppService.UpdateAsync(isBorrowed);

        //    return book2;
        //}


    }
}
