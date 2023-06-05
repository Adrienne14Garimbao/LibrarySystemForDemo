using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LibrarySystemForDemo.Authorization.Roles;
using LibrarySystemForDemo.Authorization.Users;
using LibrarySystemForDemo.MultiTenancy;

namespace LibrarySystemForDemo.EntityFrameworkCore
{
    public class LibrarySystemForDemoDbContext : AbpZeroDbContext<Tenant, Role, User, LibrarySystemForDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public LibrarySystemForDemoDbContext(DbContextOptions<LibrarySystemForDemoDbContext> options)
            : base(options)
        {
        }
    }
}
