using Ass1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ass1.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BoatContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.Boats != null && context.Boats.Any())
                    return;   // DB has already been seeded

                var ailments = DummyData.GetBoats().ToArray();
                context.Boats.AddRange(ailments);
                context.SaveChanges();

                var medications = DummyData.GetUsers().ToArray();
                context.Users.AddRange(medications);
                context.SaveChanges();
            }
        }



        public static List<Boat> GetBoats()
            {
                List<Boat> boats = new List<Boat>()
                {
                    new Boat{BoatId="0", BoatName="Boat0"},
                    new Boat{BoatId="1", BoatName="Boat1" },
                    new Boat{BoatId="2", BoatName="Boat2" },
                    new Boat{BoatId="3", BoatName="Boat3" },
                    new Boat{BoatId="4", BoatName="Boat4" }
                };
                return boats;
            }

            public static List<User> GetUsers()
            {
                List<User> users = new List<User>()
                {
                    new User{Username="0"},
                    new User{Username="1"},
                    new User{Username="2"},
                    new User{Username="3"},
                    new User{Username="4"}
                };
                return users;
            }
    }
}
