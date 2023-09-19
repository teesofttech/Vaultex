using Vaultex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vaultex.Persistence.Context
{
    public partial class VaultexContext : DbContext
    {
        public VaultexContext()
        {

        }
        public VaultexContext(DbContextOptions<VaultexContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Organisation> Organisations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
