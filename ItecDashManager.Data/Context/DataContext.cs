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

namespace ItecDashManager.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties()
                .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?)))
            {
                property.SetColumnType("timestamp without time zone");
            }
        }

        base.OnModelCreating(modelBuilder);
    }


    public DbSet<User> Users { get; set; }

}