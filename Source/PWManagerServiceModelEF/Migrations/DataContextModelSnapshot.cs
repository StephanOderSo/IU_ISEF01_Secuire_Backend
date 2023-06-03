﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PWManagerServiceModelEF;

#nullable disable

namespace PWManagerServiceModelEF.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PWManagerServiceModelEF.DataEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Favourite")
                        .HasColumnType("bit");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DataEntry");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.Login", b =>
                {
                    b.Property<int>("DataEntryId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DataEntryId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.Model.CardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CardType");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.Model.CustomTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DataEntryId")
                        .HasColumnType("int");

                    b.Property<string>("FieldContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DataEntryId");

                    b.ToTable("CustomTopic");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.PaymentCard", b =>
                {
                    b.Property<int>("DataEntryId")
                        .HasColumnType("int");

                    b.Property<int>("CardTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Cvv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DataEntryId");

                    b.HasIndex("CardTypeId");

                    b.ToTable("PaymentCard");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.SafeNote", b =>
                {
                    b.Property<int>("DataEntryId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DataEntryId");

                    b.ToTable("SafeNote");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AgbAcceptedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FailedLogins")
                        .HasColumnType("int");

                    b.Property<bool>("LockedLogin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.DataEntry", b =>
                {
                    b.HasOne("PWManagerServiceModelEF.User", null)
                        .WithMany("DataEntries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWManagerServiceModelEF.Login", b =>
                {
                    b.HasOne("PWManagerServiceModelEF.DataEntry", "DataEntry")
                        .WithMany()
                        .HasForeignKey("DataEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataEntry");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.Model.CustomTopic", b =>
                {
                    b.HasOne("PWManagerServiceModelEF.DataEntry", "DataEntry")
                        .WithMany("CustomTopics")
                        .HasForeignKey("DataEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataEntry");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.PaymentCard", b =>
                {
                    b.HasOne("PWManagerServiceModelEF.Model.CardType", "CardType")
                        .WithMany("PaymentCards")
                        .HasForeignKey("CardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PWManagerServiceModelEF.DataEntry", "DataEntry")
                        .WithMany()
                        .HasForeignKey("DataEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardType");

                    b.Navigation("DataEntry");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.SafeNote", b =>
                {
                    b.HasOne("PWManagerServiceModelEF.DataEntry", "DataEntry")
                        .WithMany()
                        .HasForeignKey("DataEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataEntry");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.DataEntry", b =>
                {
                    b.Navigation("CustomTopics");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.Model.CardType", b =>
                {
                    b.Navigation("PaymentCards");
                });

            modelBuilder.Entity("PWManagerServiceModelEF.User", b =>
                {
                    b.Navigation("DataEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
