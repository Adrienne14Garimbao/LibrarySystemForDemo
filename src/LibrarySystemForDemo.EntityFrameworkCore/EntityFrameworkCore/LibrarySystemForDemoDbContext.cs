﻿using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LibrarySystemForDemo.Authorization.Roles;
using LibrarySystemForDemo.Authorization.Users;
using LibrarySystemForDemo.MultiTenancy;
using LibrarySystemForDemo.Entities;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibrarySystemForDemo.EntityFrameworkCore
{
    public class LibrarySystemForDemoDbContext : AbpZeroDbContext<Tenant, Role, User, LibrarySystemForDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public LibrarySystemForDemoDbContext(DbContextOptions<LibrarySystemForDemoDbContext> options)
            : base(options)
        {
        }

        /* Note:  
        * 
        * Don't forget to run 'add-migration' Then > 'update-database' 
        * In Package Console Manager
        * 
        * and 
        * 
             using LibrarySystemForDemo.Entities;
            : FullAuditedEntity<int>  
        * 
        */

        public DbSet<Department> Departments { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }



    }
}
