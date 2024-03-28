using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using Dharati.Models;

namespace Dharati.DbContext1
{
    public class DharatiContext:DbContext
    {
        public DharatiContext()
        {

        }
        public DharatiContext(DbContextOptions<DharatiContext> options) : base(options)
        {

        }
        public DbSet<RegistrationModel> UserNames { get; set; }

        public DbSet<CategoryModel> Categories { get; set; }
    }
}
