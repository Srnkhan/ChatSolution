﻿// <auto-generated />
using System;
using ChatDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatDb.Data.MSSQLMigrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChatModals.DbModal.Channel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChannelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Channel");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22a1d9b0-f452-46e3-9e4a-e13739ab1dd9"),
                            ChannelName = "First Channel"
                        },
                        new
                        {
                            Id = new Guid("86c3c0d1-7d93-4286-9f39-acd12983dc07"),
                            ChannelName = "Second Channel"
                        },
                        new
                        {
                            Id = new Guid("3ce2a3be-93b3-45d6-97fa-22600e7f5a91"),
                            ChannelName = "Third Channel"
                        },
                        new
                        {
                            Id = new Guid("5feb5b2a-8d19-40f6-b142-6d6e26849a5c"),
                            ChannelName = "Fourth Channel"
                        },
                        new
                        {
                            Id = new Guid("699e8187-5ff9-4f58-befe-a3d8e2a2bdc8"),
                            ChannelName = "Fifth Channel"
                        });
                });

            modelBuilder.Entity("ChatModals.DbModal.ChannelMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("MessageId");

                    b.ToTable("ChannelMessage");
                });

            modelBuilder.Entity("ChatModals.DbModal.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserNickName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("ChatModals.DbModal.ChannelMessage", b =>
                {
                    b.HasOne("ChatModals.DbModal.Channel", "Channel")
                        .WithMany("ChannelMessages")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatModals.DbModal.Message", "Message")
                        .WithMany("ChannelMessages")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
