﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using BSCHub.DataAccess;

#nullable disable

namespace BSCHub.DataAccess.Migrations
{
    [DbContext(typeof(SocialWorkDbContext))]
    [Migration("20241108234930_User")]
    partial class User
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SocialWorkApp.Domain.Clients.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClientId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateOnly>("ISP_YearStartDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsSevere")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("NeedsBCIP")
                        .HasColumnType("boolean");

                    b.Property<bool>("NeedsPPMP")
                        .HasColumnType("boolean");

                    b.Property<int>("ProviderId")
                        .HasColumnType("integer");

                    b.HasKey("ClientId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("SocialWorkApp.Domain.Clients.ISP_Year", b =>
                {
                    b.Property<int>("ISP_YearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ISP_YearId"));

                    b.Property<DateOnly?>("BCIP_CompletedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("BCIP_ReviewedDate")
                        .HasColumnType("date");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<bool>("HasBCIP")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasPPMP")
                        .HasColumnType("boolean");

                    b.Property<DateOnly?>("MeetingDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("PBSA_CompletedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("PBSA_ReviewedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("PBSP_CompletedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("PBSP_ReviewedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("PPMP_CompletedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("PPMP_ReviewedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("SemiAnnCompletedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("SemiAnnReviewedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("ISP_YearId");

                    b.HasIndex("ClientId");

                    b.ToTable("ISP_Years");
                });

            modelBuilder.Entity("SocialWorkApp.Domain.Users.Provider", b =>
                {
                    b.Property<int>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProviderId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsIndependent")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProviderId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("SocialWorkApp.Domain.Users.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsProvider")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("ProviderId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SocialWorkApp.Domain.Clients.Client", b =>
                {
                    b.HasOne("SocialWorkApp.Domain.Users.Provider", "Provider")
                        .WithMany("Clients")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("SocialWorkApp.Domain.Clients.ISP_Year", b =>
                {
                    b.HasOne("SocialWorkApp.Domain.Clients.Client", "Client")
                        .WithMany("ISP_Years")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SocialWorkApp.Domain.Users.User", b =>
                {
                    b.HasOne("SocialWorkApp.Domain.Users.Provider", "Provider")
                        .WithOne("User")
                        .HasForeignKey("SocialWorkApp.Domain.Users.User", "ProviderId");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("SocialWorkApp.Domain.Clients.Client", b =>
                {
                    b.Navigation("ISP_Years");
                });

            modelBuilder.Entity("SocialWorkApp.Domain.Users.Provider", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
