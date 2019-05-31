﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WidgetsStorageDemo;

namespace WidgetsStorageDemo.Migrations
{
    [DbContext(typeof(WidgetsContext))]
    partial class WidgetsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WidgetsStorageDemo.Models.WidgetComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("WidgetContainerId");

                    b.HasKey("Id");

                    b.HasIndex("WidgetContainerId");

                    b.ToTable("WidgetComponents");
                });

            modelBuilder.Entity("WidgetsStorageDemo.Models.WidgetContainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("WidgetStateId");

                    b.HasKey("Id");

                    b.HasIndex("WidgetStateId");

                    b.ToTable("WidgetContainers");
                });

            modelBuilder.Entity("WidgetsStorageDemo.Models.WidgetState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("WidgetVariationId");

                    b.HasKey("Id");

                    b.HasIndex("WidgetVariationId");

                    b.ToTable("WidgetStates");
                });

            modelBuilder.Entity("WidgetsStorageDemo.Models.WidgetVariation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("WidgetVariations");
                });

            modelBuilder.Entity("WidgetsStorageDemo.Models.WidgetComponent", b =>
                {
                    b.HasOne("WidgetsStorageDemo.Models.WidgetContainer")
                        .WithMany("WidgetComponents")
                        .HasForeignKey("WidgetContainerId");
                });

            modelBuilder.Entity("WidgetsStorageDemo.Models.WidgetContainer", b =>
                {
                    b.HasOne("WidgetsStorageDemo.Models.WidgetState")
                        .WithMany("WidgetContainers")
                        .HasForeignKey("WidgetStateId");
                });

            modelBuilder.Entity("WidgetsStorageDemo.Models.WidgetState", b =>
                {
                    b.HasOne("WidgetsStorageDemo.Models.WidgetVariation")
                        .WithMany("States")
                        .HasForeignKey("WidgetVariationId");
                });
#pragma warning restore 612, 618
        }
    }
}
