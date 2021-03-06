﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using netCoreAPI.Services;

namespace netCoreAPI.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20200125031501_AddCreateOn")]
    partial class AddCreateOn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("netCoreAPI.Services.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsComplete");

                    b.Property<int>("Priority");

                    b.HasKey("Id");

                    b.ToTable("ToDos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2020, 1, 24, 19, 15, 1, 465, DateTimeKind.Local).AddTicks(2687),
                            Description = "Clean house",
                            IsComplete = false,
                            Priority = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2020, 1, 24, 19, 15, 1, 466, DateTimeKind.Local).AddTicks(9318),
                            Description = "Bake cake",
                            IsComplete = false,
                            Priority = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
