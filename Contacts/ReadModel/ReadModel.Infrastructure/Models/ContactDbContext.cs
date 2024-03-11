using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReadModel.Infrastructure.Models;

public partial class ContactReadDbContext : DbContext
{
    public ContactReadDbContext()
    {
    }

    public ContactReadDbContext(DbContextOptions<ContactReadDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact", "Domain");

            entity.HasIndex(e => new { e.FirstName, e.LastName }, "IX_Contact_FirstName_LastName").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => new { e.ContactId, e.Id });

            entity.ToTable("Phone", "Domain");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Contact).WithMany(p => p.Phones).HasForeignKey(d => d.ContactId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
