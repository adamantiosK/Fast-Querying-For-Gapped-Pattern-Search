﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FSGPM.Migrations
{
    [DbContext(typeof(DTUcontext))]
    [Migration("20230522193427_updaet storage format for suffix arrays")]
    partial class updaetstorageformatforsuffixarrays
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FSGPM.DataAccess.AlgoDataSetResult", b =>
                {
                    b.Property<Guid>("AlgoResultGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlgorithmName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ConstraintCountGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DS_Result_Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DataSetGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("K_Selection")
                        .HasColumnType("int");

                    b.Property<long>("Miliseconds")
                        .HasColumnType("bigint");

                    b.Property<long>("Miliseconds_AverageRun")
                        .HasColumnType("bigint");

                    b.Property<long>("Miliseconds_Preproccesing")
                        .HasColumnType("bigint");

                    b.Property<int>("PatternLength")
                        .HasColumnType("int");

                    b.Property<int>("PatternsFound")
                        .HasColumnType("int");

                    b.HasKey("AlgoResultGuid");

                    b.ToTable("AlgoDataSetResults");
                });

            modelBuilder.Entity("FSGPM.DataAccess.AlgoDataSetResultApproved", b =>
                {
                    b.Property<Guid>("AlgoResultGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlgorithmName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ConstraintCountGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DS_Result_Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DataSetGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("K_Selection")
                        .HasColumnType("int");

                    b.Property<long>("Miliseconds")
                        .HasColumnType("bigint");

                    b.Property<long>("Miliseconds_AverageRun")
                        .HasColumnType("bigint");

                    b.Property<long>("Miliseconds_Preproccesing")
                        .HasColumnType("bigint");

                    b.Property<int>("PatternLength")
                        .HasColumnType("int");

                    b.Property<int>("PatternsFound")
                        .HasColumnType("int");

                    b.HasKey("AlgoResultGuid");

                    b.ToTable("AlgoDataSetResultsApproved");
                });

            modelBuilder.Entity("FSGPM.DataAccess.Constraint", b =>
                {
                    b.Property<Guid>("ConstraintGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConstraintCountGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataSetGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.HasKey("ConstraintGuid");

                    b.ToTable("Constraints");
                });

            modelBuilder.Entity("FSGPM.DataAccess.ConstraintCount", b =>
                {
                    b.Property<Guid>("ConstraintCountGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ConstraintMax")
                        .HasColumnType("int");

                    b.Property<int>("ConstraintMin")
                        .HasColumnType("int");

                    b.HasKey("ConstraintCountGuid");

                    b.ToTable("ConstraintCounts");
                });

            modelBuilder.Entity("FSGPM.DataAccess.DataSet", b =>
                {
                    b.Property<Guid>("DataSetGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AvailableToRun")
                        .HasColumnType("bit");

                    b.Property<string>("DataSetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OverHeadMsCalculated")
                        .HasColumnType("bigint");

                    b.Property<bool>("SACalculated")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DataSetGuid");

                    b.ToTable("DataSets");
                });

            modelBuilder.Entity("FSGPM.DataAccess.Pattern", b =>
                {
                    b.Property<Guid>("PatternGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataSetGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DefaultPatternLength")
                        .HasColumnType("bit");

                    b.Property<string>("PatternText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatternGuid");

                    b.ToTable("Patterns");
                });

            modelBuilder.Entity("FSGPM.DataAccess.ReportStatus", b =>
                {
                    b.Property<Guid>("StatusGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProgressStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ReportCompleted")
                        .HasColumnType("bit");

                    b.HasKey("StatusGuid");

                    b.ToTable("ReportStatuses");
                });

            modelBuilder.Entity("SuffixArraySet", b =>
                {
                    b.Property<Guid>("SuffixArrayGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DataSetGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SuffixArray")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuffixArrayGuid");

                    b.ToTable("SuffixArraySets");
                });
#pragma warning restore 612, 618
        }
    }
}
