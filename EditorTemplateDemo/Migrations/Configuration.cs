namespace EditorTemplateDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<EditorTemplateDemo.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EditorTemplateDemo.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.CustomerTypes.AddOrUpdate(c => c.Description,
                new CustomerType() {Description = "Loyal"},
                new CustomerType() {Description = "Discount"},
                new CustomerType() {Description = "Impulse"},
                new CustomerType() {Description = "Need Based"},
                new CustomerType() {Description = "Wandering"});

            context.SaveChanges();

            context.Customers.AddOrUpdate(c=> new {c.FirstName, c.LastName},
                new Customer { FirstName = "Betty", LastName = "Bradley", Initial = "Y", IsActive = true, CustomerTypeId = 1 },
                new Customer { FirstName = "Sara", LastName = "Sims", Initial = "J", IsActive = true, CustomerTypeId = 3 },
                new Customer { FirstName = "Evelyn", LastName = "Watkins", Initial = "E", IsActive = true, CustomerTypeId = 1 },
                new Customer { FirstName = "Randy", LastName = "Holmes", Initial = "P", IsActive = false, CustomerTypeId = 5 },
                new Customer { FirstName = "James", LastName = "Turner", Initial = "B", IsActive = false, CustomerTypeId = 1 },
                new Customer { FirstName = "Kevin", LastName = "Knight", Initial = "L", IsActive = false, CustomerTypeId = 3 },
                new Customer { FirstName = "Mark", LastName = "Anderson", Initial = "V", IsActive = true, CustomerTypeId = 1 },
                new Customer { FirstName = "Nancy", LastName = "Murphy", Initial = "J", IsActive = true, CustomerTypeId = 5 },
                new Customer { FirstName = "Karen", LastName = "Bell", Initial = "G", IsActive = true, CustomerTypeId = 2 },
                new Customer { FirstName = "Carl", LastName = "Meyer", Initial = "Y", IsActive = false, CustomerTypeId = 3 },
                new Customer { FirstName = "Kimberly", LastName = "Holmes", Initial = "V", IsActive = false, CustomerTypeId = 4 },
                new Customer { FirstName = "George", LastName = "Wallace", Initial = "Z", IsActive = true, CustomerTypeId = 2 },
                new Customer { FirstName = "Martha", LastName = "Matthews", Initial = "U", IsActive = true, CustomerTypeId = 4 },
                new Customer { FirstName = "Charles", LastName = "Myers", Initial = "N", IsActive = false, CustomerTypeId = 1 },
                new Customer { FirstName = "Jean", LastName = "Cooper", Initial = "B", IsActive = true, CustomerTypeId = 3 },
                new Customer { FirstName = "Eric", LastName = "Simpson", Initial = "", IsActive = false, CustomerTypeId = 1 },
                new Customer { FirstName = "Lillian", LastName = "Turner", Initial = "C", IsActive = false, CustomerTypeId = 3 },
                new Customer { FirstName = "Sara", LastName = "Palmer", Initial = "B", IsActive = false, CustomerTypeId = 5 },
                new Customer { FirstName = "Jose", LastName = "Murray", Initial = "", IsActive = false, CustomerTypeId = 5 },
                new Customer { FirstName = "Donald", LastName = "Gray", Initial = "", IsActive = false, CustomerTypeId = 2 },
                new Customer { FirstName = "Donna", LastName = "Murray", Initial = "J", IsActive = true, CustomerTypeId = 5 },
                new Customer { FirstName = "Virginia", LastName = "Owens", Initial = "Z", IsActive = true, CustomerTypeId = 5 },
                new Customer { FirstName = "Lori", LastName = "Bell", Initial = "W", IsActive = false, CustomerTypeId = 3 },
                new Customer { FirstName = "Billy", LastName = "Hayes", Initial = "A", IsActive = true, CustomerTypeId = 1 },
                new Customer { FirstName = "Elizabeth", LastName = "Wheeler", Initial = "G", IsActive = true, CustomerTypeId = 3 }

                );

            context.SaveChanges();
        }
    }
}
