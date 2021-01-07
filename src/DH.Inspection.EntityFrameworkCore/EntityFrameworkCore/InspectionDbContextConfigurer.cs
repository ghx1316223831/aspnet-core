using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DH.Inspection.EntityFrameworkCore
{
    public static class InspectionDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<InspectionDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<InspectionDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
