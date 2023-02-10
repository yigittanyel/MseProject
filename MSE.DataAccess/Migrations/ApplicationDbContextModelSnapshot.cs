﻿// <auto-generated />
using System;
using MSE.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MSE.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MaintenancePersonnelWorkStation", b =>
                {
                    b.Property<int>("MaintenancePersonnelsMaintenancePersonnelId")
                        .HasColumnType("int");

                    b.Property<int>("WorkStationsWorkStationId")
                        .HasColumnType("int");

                    b.HasKey("MaintenancePersonnelsMaintenancePersonnelId", "WorkStationsWorkStationId");

                    b.HasIndex("WorkStationsWorkStationId");

                    b.ToTable("MaintenancePersonnelWorkStation", (string)null);
                });

            modelBuilder.Entity("MSE.Entity.Entities.Concrete.Alarm", b =>
                {
                    b.Property<int>("AlarmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlarmId"), 1L, 1);

                    b.Property<decimal>("MaxPressure")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MaxTemperature")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MinPressure")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MinTemperature")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("WorkStationId")
                        .HasColumnType("int");

                    b.HasKey("AlarmId");

                    b.HasIndex("WorkStationId");

                    b.ToTable("Alarms", (string)null);
                });

            modelBuilder.Entity("MSE.Entity.Entities.Concrete.EmailData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmailDatas", (string)null);
                });

            modelBuilder.Entity("MSE.Entity.Entities.Concrete.MaintenancePersonnel", b =>
                {
                    b.Property<int>("MaintenancePersonnelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaintenancePersonnelId"), 1L, 1);

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaintenancePersonnelId");

                    b.ToTable("MaintenancePersonnels", (string)null);
                });

            modelBuilder.Entity("MSE.Entity.Entities.Concrete.ProductionLine", b =>
                {
                    b.Property<int>("ProductionLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductionLineId"), 1L, 1);

                    b.Property<DateTime>("FirstProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductionLineName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProductionLineId");

                    b.ToTable("ProductionLines", (string)null);
                });

            modelBuilder.Entity("MSE.Entity.Entities.Concrete.WorkStation", b =>
                {
                    b.Property<int>("WorkStationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkStationId"), 1L, 1);

                    b.Property<decimal>("Pressure")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductionLineId")
                        .HasColumnType("int");

                    b.Property<string>("StationName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal>("Temperature")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("WorkStationId");

                    b.HasIndex("ProductionLineId");

                    b.ToTable("WorkStations", (string)null);
                });

            modelBuilder.Entity("MSE.Entity.Entities.Concrete.WorkStationPersonnel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MaintenancePersonnelId")
                        .HasColumnType("int");

                    b.Property<int>("WorkStationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaintenancePersonnelId");

                    b.HasIndex("WorkStationId");

                    b.ToTable("WorkStationPersonnels", (string)null);
                });

            modelBuilder.Entity("MaintenancePersonnelWorkStation", b =>
                {
                    b.HasOne("MSE.Entity.Entities.Concrete.MaintenancePersonnel", null)
                        .WithMany()
                        .HasForeignKey("MaintenancePersonnelsMaintenancePersonnelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MSE.Entity.Entities.Concrete.WorkStation", null)
                        .WithMany()
                        .HasForeignKey("WorkStationsWorkStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MSE.Entity.Entities.Concrete.Alarm", b =>
                {
                    b.HasOne("MSE.Entity.Entities.Concrete.WorkStation", "WorkStation")
                        .WithMany("Alarms")
                        .HasForeignKey("WorkStationId");

                    b.Navigation("WorkStation");
                });

            modelBuilder.Entity("MSE.Entity.Entities.Concrete.WorkStation", b =>
                {
                    b.HasOne("MSE.Entity.Entities.Concrete.ProductionLine", "ProductionLine")
                        .WithMany("WorkStations")
                        .HasForeignKey("ProductionLineId");

                    b.Navigation("ProductionLine");
                });

            modelBuilder.Entity("MSE.Entity.Entities.Concrete.WorkStationPersonnel", b =>
                {
                    b.HasOne("MSE.Entity.Entities.Concrete.MaintenancePersonnel", "MaintenancePersonnel")
                        .WithMany()
                        .HasForeignKey("MaintenancePersonnelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MSE.Entity.Entities.Concrete.WorkStation", "WorkStation")
                        .WithMany()
                        .HasForeignKey("WorkStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaintenancePersonnel");

                    b.Navigation("WorkStation");
                });

            modelBuilder.Entity("MSE.Entity.Entities.Concrete.ProductionLine", b =>
                {
                    b.Navigation("WorkStations");
                });

            modelBuilder.Entity("MSE.Entity.Entities.Concrete.WorkStation", b =>
                {
                    b.Navigation("Alarms");
                });
#pragma warning restore 612, 618
        }
    }
}
