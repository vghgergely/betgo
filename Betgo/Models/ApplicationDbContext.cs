using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Betgo.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Competitor> Competitors { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Event>().HasMany(e => e.Competitor).WithRequired().WillCascadeOnDelete(false);

            
            base.OnModelCreating(modelBuilder);
        }

    }
}