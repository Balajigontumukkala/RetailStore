using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RetailStore.Api.MetaDataBL.Category.Models;
using RetailStore.Api.MetaDataBL.Department.Models;
using RetailStore.Api.MetaDataBL.Location.Models;
using RetailStore.Api.MetaDataBL.Login.Models;
using RetailStore.Api.MetaDataBL.SkuDetails.Models;
using RetailStore.Api.MetaDataBL.Subcategory.Models;

namespace RetailStore.Api.MetaDataBL.Repository
{
    public class MetaDataDBContext : IdentityDbContext<ApplicationUser>
    {
        public MetaDataDBContext(DbContextOptions<MetaDataDBContext> options) :
            base(options)
        { }

        public DbSet<LocationModel> LocationModel { get; set; }

        public DbSet<DepartmentModel> DepartmentModel { get; set; }

        public DbSet<CategoryModel> CategoryModel { get; set; }

        public DbSet<SubcategoryModel> SubcategoryModel { get; set; }

        public DbSet<SkuDetailsModel> SkuDetailsModel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<IdentityUser>().ToTable("IdentityUser");
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
