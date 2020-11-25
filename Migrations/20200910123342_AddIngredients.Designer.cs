﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMealPlanner.Models;

namespace MyMealPlanner.Migrations
{
    [DbContext(typeof(MealPlannerContext))]
    [Migration("20200910123342_AddIngredients")]
    partial class AddIngredients
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyMealPlanner.Models.IngredientType", b =>
                {
                    b.Property<long>("IngredientTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("IngredientTypeName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IngredientTypeId");

                    b.ToTable("IngredientTypes");
                });

            modelBuilder.Entity("MyMealPlanner.Models.Ingredients", b =>
                {
                    b.Property<long>("IngredientsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("IngredientTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("MealId")
                        .HasColumnType("bigint");

                    b.HasKey("IngredientsId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("MyMealPlanner.Models.Meal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cuisine")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MealName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MealType")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("MealRepo");
                });

            modelBuilder.Entity("MyMealPlanner.Models.MealPlan", b =>
                {
                    b.Property<long>("MealId")
                        .HasColumnType("bigint");

                    b.Property<long>("MealTimeId")
                        .HasColumnType("bigint");

                    b.HasKey("MealId", "MealTimeId");

                    b.HasIndex("MealTimeId");

                    b.ToTable("MealPlan");
                });

            modelBuilder.Entity("MyMealPlanner.Models.MealTime", b =>
                {
                    b.Property<long>("MealTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("MealTimeId");

                    b.ToTable("MealTimes");
                });

            modelBuilder.Entity("MyMealPlanner.Models.MealPlan", b =>
                {
                    b.HasOne("MyMealPlanner.Models.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyMealPlanner.Models.MealTime", "MealTime")
                        .WithMany()
                        .HasForeignKey("MealTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
