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
                new EventType { Name = "Soccer" },
                new EventType { Name = "Fencing" },
                new EventType { Name = "MMA" },
                new EventType { Name = "Judo" });

            context.Competitors.AddOrUpdate(t => t.Name,
                new Competitor { Name = "Mike Tyson", Odds = 2.0, Type = context.EventTypes.Find(3) },
                new Competitor { Name = "Fence the Fans Away", Odds = 3.0, Type = context.EventTypes.Find(2) },
                new Competitor { Name = "Juno Judo", Odds = 0.8, Type = context.EventTypes.Find(1) },
                new Competitor { Name = "Ohmy God", Odds = 0.2, Type = context.EventTypes.Find(4) },
                new Competitor { Name = "Hingle McCringleberry", Odds = 4.0, Type = context.EventTypes.Find(2) }
                );

       
        }

       
    }
}
