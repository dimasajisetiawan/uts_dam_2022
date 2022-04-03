﻿// <auto-generated />
using System;
using DentalApps.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DentalApps.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DentalApps.Models.DoctorSchedule", b =>
                {
                    b.Property<int>("DoctorScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorScheduleID"), 1L, 1);

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DoctorScheduleID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("DoctorSchedules");
                });

            modelBuilder.Entity("DentalApps.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TenantID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("TenantID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DentalApps.Models.Patient", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BPJSNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedicalRecordNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TenantID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.HasIndex("MedicalRecordNumber")
                        .IsUnique();

                    b.HasIndex("TenantID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DentalApps.Models.RegisterSchedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleID"), 1L, 1);

                    b.Property<int>("DoctorScheduleID")
                        .HasColumnType("int");

                    b.Property<string>("PatientID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ScheduleID");

                    b.HasIndex("DoctorScheduleID");

                    b.HasIndex("PatientID");

                    b.ToTable("RegisterSchedules");
                });

            modelBuilder.Entity("DentalApps.Models.SubTreatment", b =>
                {
                    b.Property<int>("SubTreatmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubTreatmentID"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SubTreatmentCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("TreatmentID")
                        .HasColumnType("int");

                    b.HasKey("SubTreatmentID");

                    b.HasIndex("TreatmentID");

                    b.ToTable("SubTreatments");
                });

            modelBuilder.Entity("DentalApps.Models.SubTreatmentCategory", b =>
                {
                    b.Property<int>("SubTreatmentCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubTreatmentCategoryID"), 1L, 1);

                    b.Property<decimal?>("DefaultPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTreatmentCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TreatmentCategoryID")
                        .HasColumnType("int");

                    b.HasKey("SubTreatmentCategoryID");

                    b.HasIndex("TreatmentCategoryID");

                    b.ToTable("SubTreatmentCategories");
                });

            modelBuilder.Entity("DentalApps.Models.Tenant", b =>
                {
                    b.Property<string>("TenantID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PrefixMR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantStatus")
                        .HasColumnType("int");

                    b.HasKey("TenantID");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("DentalApps.Models.Treatment", b =>
                {
                    b.Property<int>("TreatmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TreatmentID"), 1L, 1);

                    b.Property<string>("Anamnesis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Recipe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TreatmentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TreatmentID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("PatientID");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("DentalApps.Models.TreatmentCategory", b =>
                {
                    b.Property<int>("TreatmentCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TreatmentCategoryID"), 1L, 1);

                    b.Property<string>("TenantID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TreatmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TreatmentCategoryID");

                    b.ToTable("TreatmentCategories");
                });

            modelBuilder.Entity("DentalApps.Models.DoctorSchedule", b =>
                {
                    b.HasOne("DentalApps.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DentalApps.Models.Employee", b =>
                {
                    b.HasOne("DentalApps.Models.Tenant", "Tenant")
                        .WithMany("Employees")
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("DentalApps.Models.Patient", b =>
                {
                    b.HasOne("DentalApps.Models.Tenant", "Tenant")
                        .WithMany("Patients")
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("DentalApps.Models.RegisterSchedule", b =>
                {
                    b.HasOne("DentalApps.Models.DoctorSchedule", "DoctorSchedule")
                        .WithMany()
                        .HasForeignKey("DoctorScheduleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalApps.Models.Patient", "Patient")
                        .WithMany("RegisterSchedules")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DoctorSchedule");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DentalApps.Models.SubTreatment", b =>
                {
                    b.HasOne("DentalApps.Models.Treatment", "Treatment")
                        .WithMany("SubTreatments")
                        .HasForeignKey("TreatmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("DentalApps.Models.SubTreatmentCategory", b =>
                {
                    b.HasOne("DentalApps.Models.TreatmentCategory", "TreatmentCategory")
                        .WithMany("SubTreatmentCategories")
                        .HasForeignKey("TreatmentCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TreatmentCategory");
                });

            modelBuilder.Entity("DentalApps.Models.Treatment", b =>
                {
                    b.HasOne("DentalApps.Models.Employee", "Employee")
                        .WithMany("Treatments")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalApps.Models.Patient", "Patient")
                        .WithMany("Treatments")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DentalApps.Models.Employee", b =>
                {
                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("DentalApps.Models.Patient", b =>
                {
                    b.Navigation("RegisterSchedules");

                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("DentalApps.Models.Tenant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("DentalApps.Models.Treatment", b =>
                {
                    b.Navigation("SubTreatments");
                });

            modelBuilder.Entity("DentalApps.Models.TreatmentCategory", b =>
                {
                    b.Navigation("SubTreatmentCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
