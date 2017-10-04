using Betgo.Models;

namespace Betgo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Betgo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Betgo.Models.ApplicationDbContext context)
        {
            context.EventTypes.AddOrUpdate(t => t.Name,
                new EventType {Name = "Soccer"},
                new EventType {Name = "Fencing"},
                new EventType {Name = "MMA"},
                new EventType {Name = "Judo"});

        }
    }
}
