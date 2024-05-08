using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EduVise.EntityFrameworkCore
{
    public static class EduViseDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<EduViseDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<EduViseDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
