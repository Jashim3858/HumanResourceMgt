using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HumanResourceManagement.Models
{

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Add New
        public class PayrollDbContext : DbContext
        {

            public DbSet<Payroll> Movies { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Payroll>().MapToStoredProcedures();
                base.OnModelCreating(modelBuilder);
            }
        }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private string v;

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public ApplicationDbContext(string v)
        {
            this.v = v;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<HumanResourceManagement.Models.Location> Locations { get; set; }

        public System.Data.Entity.DbSet<HumanResourceManagement.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<HumanResourceManagement.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<HumanResourceManagement.Models.Payroll> Payrolls { get; set; }
    }
}