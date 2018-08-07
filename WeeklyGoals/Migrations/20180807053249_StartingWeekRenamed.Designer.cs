﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WeeklyGoals.Models;

namespace WeeklyGoals.Migrations
{
    [DbContext(typeof(GoalsContext))]
    [Migration("20180807053249_StartingWeekRenamed")]
    partial class StartingWeekRenamed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeeklyGoals.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Factor");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("StartingWeek")
                        .IsRequired();

                    b.Property<int>("StepSize");

                    b.Property<string>("Unit")
                        .IsRequired();

                    b.Property<int>("WeeklyTarget");

                    b.HasKey("Id");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("WeeklyGoals.Models.Progress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GoalId");

                    b.Property<double>("Points");

                    b.Property<int?>("WeekId");

                    b.HasKey("Id");

                    b.HasIndex("GoalId");

                    b.HasIndex("WeekId");

                    b.ToTable("Progress");
                });

            modelBuilder.Entity("WeeklyGoals.Models.Week", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.ToTable("Weeks");
                });

            modelBuilder.Entity("WeeklyGoals.Models.Progress", b =>
                {
                    b.HasOne("WeeklyGoals.Models.Goal", "Goal")
                        .WithMany("Progress")
                        .HasForeignKey("GoalId");

                    b.HasOne("WeeklyGoals.Models.Week", "Week")
                        .WithMany("Progress")
                        .HasForeignKey("WeekId");
                });
#pragma warning restore 612, 618
        }
    }
}
