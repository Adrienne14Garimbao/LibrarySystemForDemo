using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemForDemo.EntityFrameworkCore
{
    public static class LibrarySystemForDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LibrarySystemForDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LibrarySystemForDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
