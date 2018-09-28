using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InfnetPos.Mvc.TrabalhoFinal.Infrastructure.Data.Context
{
    public class InfnetPosMvcContextFactory : IDesignTimeDbContextFactory<InfnetPosMvcContext>
    {
        public InfnetPosMvcContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InfnetPosMvcContext>();
            optionsBuilder.UseSqlServer(
                "Server=fva;Database=InfnetPosMvc;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new InfnetPosMvcContext(optionsBuilder.Options);
        }
    }
}