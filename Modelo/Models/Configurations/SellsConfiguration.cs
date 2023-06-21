﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Models;
using System;
using System.Collections.Generic;

namespace Model.Models.Configurations
{
    public partial class SellsConfiguration : IEntityTypeConfiguration<Sells>
    {
        public void Configure(EntityTypeBuilder<Sells> entity)
        {
            entity.HasKey(e => new { e.Id, e.IdMedicine, e.IdUser })
                .HasName("PK__Sells__DF40F8B417684198");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.IdMedicine).HasColumnName("idMedicine");

            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");

            entity.Property(e => e.SellDate)
                .HasColumnType("datetime")
                .HasColumnName("sellDate");

            entity.HasOne(d => d.IdMedicineNavigation)
                .WithMany(p => p.Sells)
                .HasForeignKey(d => d.IdMedicine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sells__idMedicin__06CD04F7");

            entity.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Sells)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sells__idUser__07C12930");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Sells> entity);
    }
}
