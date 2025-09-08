using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ItecDashManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Linq;
using System;
using ItecDashManager.Domain.Entities.User;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using ItecDashManager.Domain.Entities.Dashboard;
using ItecDashManager.Domain.Entities.UserDashboard;

namespace ItecDashManager.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
       
        configurationBuilder
            .Properties<DateTime>()
            .HaveColumnType("timestamp without time zone");

       
        configurationBuilder
            .Properties<DateTime?>()
            .HaveColumnType("timestamp without time zone");
    }

   
    public DbSet<User> Users { get; set; }
    public DbSet<Dashboard> Dashboards { get; set; }
    public DbSet<UserDashboard> UserDashboards { get; set; }

}