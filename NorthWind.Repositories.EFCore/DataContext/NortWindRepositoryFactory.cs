using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.EFCore
{
    public class NortWindRepositoryFactory : IDesignTimeDbContextFactory<NorthWindContext>
    {
        public NorthWindContext CreateDbContext(string[] args)
        {
            // make option builder
            var optionBuilder = new DbContextOptionsBuilder<NorthWindContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=NorthwindCleanCode");

            return new NorthWindContext(optionBuilder.Options);



        }
    }
}
