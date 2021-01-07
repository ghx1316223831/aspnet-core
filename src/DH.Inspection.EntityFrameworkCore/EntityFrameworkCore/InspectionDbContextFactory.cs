using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DH.Inspection.Configuration;
using DH.Inspection.Web;

namespace DH.Inspection.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class InspectionDbContextFactory : IDesignTimeDbContextFactory<InspectionDbContext>
    {
        public InspectionDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<InspectionDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            InspectionDbContextConfigurer.Configure(builder, configuration.GetConnectionString(InspectionConsts.ConnectionStringName));

            return new InspectionDbContext(builder.Options);
        }
    }
}
