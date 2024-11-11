﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelPlanner.Data;

#nullable disable

namespace JourneyMatePublicActiveCloudSite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241111042906_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("JourneyMate_Public_Active_Cloud_Site.Models.Itinerary", b =>
                {
                    b.Property<int>("ItineraryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Activities")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Budget")
                        .HasColumnType("TEXT");

                    b.Property<int>("DayNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemsToBring")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("TripId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItineraryId");

                    b.HasIndex("TripId");

                    b.ToTable("Itineraries");
                });

            modelBuilder.Entity("JourneyMate_Public_Active_Cloud_Site.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("TripId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("JourneyMate_Public_Active_Cloud_Site.Models.Itinerary", b =>
                {
                    b.HasOne("JourneyMate_Public_Active_Cloud_Site.Models.Trip", "Trip")
                        .WithMany("Itineraries")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("JourneyMate_Public_Active_Cloud_Site.Models.Trip", b =>
                {
                    b.Navigation("Itineraries");
                });
#pragma warning restore 612, 618
        }
    }
}
