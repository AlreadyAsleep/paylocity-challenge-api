using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaylocityCodingChallenge.Objects;
using Microsoft.EntityFrameworkCore;
using PaylocityCodingChallenge.Data.Context.Mappers;

namespace PaylocityCodingChallenge.Data.Context
{
    public partial class EmployeeDbContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Dependent> Dependents { get; set; }
        public virtual DbSet<BenefitRate> BenefitRates { get; set; }
        public virtual DbSet<DiscountRate> Discounts { get; set; }
        private readonly bool _inMemory;

        public EmployeeDbContext(bool inMemory = false)
        {
            _inMemory = inMemory;
        }

        private EmployeeDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Called when the context is created, used for configuring the connection to a db, or inMemory for testing
        /// </summary>
        /// <param name="optionsBuilder">a container for various options around the context</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (_inMemory)
                {
                    optionsBuilder.UseInMemoryDatabase("InMemoryDb");
                }
                else
                {
                    optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=PaylocityTest;Trusted_Connection=True;");
                }
            }
        }

        /// <summary>
        /// called when the context is created, used for mapping domain models to database entities
        /// </summary>
        /// <param name="builder">An object containing all of the model-to-entity bindings</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.MapEmployees();
            builder.MapDependents();
            builder.MapBenefitRates();
            builder.MapDiscounts();
        }
    }
}