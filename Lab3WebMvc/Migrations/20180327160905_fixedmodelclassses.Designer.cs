﻿// <auto-generated />
using Lab3WebMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Lab3WebMvc.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20180327160905_fixedmodelclassses")]
    partial class fixedmodelclassses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab3WebMvc.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SeatsTaken");

                    b.Property<double>("Starting");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("MovieId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("Lab3WebMvc.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MovieId");

                    b.Property<int>("VisitorId");

                    b.HasKey("TicketId");

                    b.HasIndex("MovieId");

                    b.HasIndex("VisitorId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Lab3WebMvc.Models.Visitor", b =>
                {
                    b.Property<int>("VisitorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("TicketCount");

                    b.HasKey("VisitorId");

                    b.ToTable("Visitor");
                });

            modelBuilder.Entity("Lab3WebMvc.Models.Ticket", b =>
                {
                    b.HasOne("Lab3WebMvc.Models.Movie", "Movie")
                        .WithMany("Tickets")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Lab3WebMvc.Models.Visitor", "Visitor")
                        .WithMany("Tickets")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
