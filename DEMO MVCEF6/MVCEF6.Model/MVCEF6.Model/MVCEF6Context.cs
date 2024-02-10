using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCEF6.Model
{
    public class MVCEF6Context : DbContext
    {

        public MVCEF6Context()
            : base("MVCEF6Context")
        {
        }

        public DbSet<Testmodel> Students { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<MVCEF6.Model.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<MVCEF6.Model.User> Users { get; set; }
    }
}
