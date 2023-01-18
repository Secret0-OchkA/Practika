﻿// <auto-generated />
using System;
using Infrastructura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructura.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230118130738_addOrder")]
    partial class addOrder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Blood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("barcode")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Bloods");
                });

            modelBuilder.Entity("Domain.BloodService", b =>
                {
                    b.Property<int>("BloodId")
                        .HasColumnType("int");

                    b.Property<bool>("accepted")
                        .HasColumnType("bit");

                    b.Property<string>("analyzer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("finished")
                        .HasColumnType("float");

                    b.Property<double>("result")
                        .HasColumnType("float");

                    b.Property<int>("serviceCode")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasIndex("BloodId");

                    b.HasIndex("serviceCode");

                    b.HasIndex("userId");

                    b.ToTable("bloodServices");
                });

            modelBuilder.Entity("Domain.HistoryRow", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("EnterTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("confirmEnter")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("exitTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("History");
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SocialSecNumber")
                        .HasColumnType("int");

                    b.Property<string>("SocialSecType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ein")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Domain.Report", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Domain.Service", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Service");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Code");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Domain.ServiceInOrder", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PatientBloodId")
                        .HasColumnType("int");

                    b.Property<int>("serviceCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PatientBloodId");

                    b.HasIndex("serviceCode");

                    b.ToTable("ServiceInOrder");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("lastenter")
                        .HasColumnType("datetime2");

                    b.Property<string>("services")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Blood", b =>
                {
                    b.HasOne("Domain.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.BloodService", b =>
                {
                    b.HasOne("Domain.Blood", "Blood")
                        .WithMany()
                        .HasForeignKey("BloodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Service", "service")
                        .WithMany()
                        .HasForeignKey("serviceCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blood");

                    b.Navigation("service");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.HasOne("Domain.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Patient", b =>
                {
                    b.OwnsOne("Domain.Insurance", "Company", b1 =>
                        {
                            b1.Property<int>("PatientId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Bik")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Inn")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PaymentAccount")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.OwnsOne("Domain.Passport", "Passport", b1 =>
                        {
                            b1.Property<int>("PatientId")
                                .HasColumnType("int");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Serial")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.OwnsOne("Domain.Identity", "user", b1 =>
                        {
                            b1.Property<int>("PatientId")
                                .HasColumnType("int");

                            b1.Property<string>("Ip")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("lastenter")
                                .HasColumnType("datetime2");

                            b1.Property<string>("login")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("password")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("role")
                                .HasColumnType("int");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.OwnsOne("Domain.Person", "person", b1 =>
                        {
                            b1.Property<int>("PatientId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Birthdate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.Navigation("Company")
                        .IsRequired();

                    b.Navigation("Passport")
                        .IsRequired();

                    b.Navigation("person")
                        .IsRequired();

                    b.Navigation("user")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.ServiceInOrder", b =>
                {
                    b.HasOne("Domain.Order", null)
                        .WithMany("serviceInOrders")
                        .HasForeignKey("OrderId");

                    b.HasOne("Domain.Blood", "PatientBlood")
                        .WithMany()
                        .HasForeignKey("PatientBloodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Service", "service")
                        .WithMany()
                        .HasForeignKey("serviceCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PatientBlood");

                    b.Navigation("service");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.OwnsOne("Domain.Identity", "identity", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Ip")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("lastenter")
                                .HasColumnType("datetime2");

                            b1.Property<string>("login")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("password")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("role")
                                .HasColumnType("int");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("identity")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.Navigation("serviceInOrders");
                });
#pragma warning restore 612, 618
        }
    }
}