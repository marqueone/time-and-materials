using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Marqueone.TimeAndMaterials.Api.Entities;
using Marqueone.TimeAndMaterials.Api.Entities.Relationships;

namespace Marqueone.TimeAndMaterials.Api.DataAccess
{
  public class TamContext : DbContext
  {
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactMethod> ContactMethods { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<Trade> Trades { get; set; }
    public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }

    //-- joining Relationships
    internal DbSet<EmployeeTrade> EmployeeTrades { get; set; }
    internal DbSet<MaterialWorkOrder> MaterialWorkOrders { get; set; }

    ILogger<TamContext> _logger;

    public TamContext(DbContextOptions<TamContext> options, ILogger<TamContext> logger) : base(options)
    {
      _logger = logger;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      //-- employee <--> trade
      builder.Entity<EmployeeTrade>()
        .HasKey(et => new { et.EmployeeId, et.TradeId });

      builder.Entity<EmployeeTrade>()
          .HasOne(et => et.Employee)
          .WithMany(et => et.EmployeeTrades)
          .HasForeignKey(et => et.EmployeeId);

      builder.Entity<EmployeeTrade>()
          .HasOne(et => et.Trade)
          .WithMany(et => et.EmployeeTrades)
          .HasForeignKey(et => et.TradeId);

      //-- project <--> workorder 
      builder.Entity<MaterialWorkOrder>()
        .HasKey(et => new { et.MaterialId, et.WorkOrderId });

      builder.Entity<MaterialWorkOrder>()
          .HasOne(et => et.Material)
          .WithMany(et => et.MaterialWorkOrders)
          .HasForeignKey(et => et.MaterialId);

      builder.Entity<MaterialWorkOrder>()
          .HasOne(et => et.WorkOrder)
          .WithMany(et => et.MaterialWorkOrders)
          .HasForeignKey(et => et.WorkOrderId);

      base.OnModelCreating(builder);
    }
  }
}