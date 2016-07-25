using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCore.POC.ChildComplexType.DataAccess.Local;

namespace EFCore.POC.ChildComplexType.Migrations
{
    [DbContext(typeof(POCContext))]
    [Migration("20160725220735_v0")]
    partial class v0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("EFCore.POC.ChildComplexType.Domain.RefundType", b =>
                {
                    b.Property<int>("RefundTypeId");

                    b.Property<long>("CreatedAt");

                    b.Property<string>("DarkIcon");

                    b.Property<string>("HelpText");

                    b.Property<bool>("IsAttachmentRequired");

                    b.Property<bool>("IsCommentRequired");

                    b.Property<bool>("IsPeopleRequired");

                    b.Property<string>("LightIcon");

                    b.Property<string>("Name");

                    b.Property<int>("RefundUnitId");

                    b.Property<long>("UpdatedAt");

                    b.HasKey("RefundTypeId");

                    b.HasIndex("RefundUnitId");

                    b.ToTable("RefundType");
                });

            modelBuilder.Entity("EFCore.POC.ChildComplexType.Domain.RefundUnit", b =>
                {
                    b.Property<int>("RefundUnitId");

                    b.Property<string>("Acronym");

                    b.Property<string>("ActiveIndicator");

                    b.Property<bool>("Item");

                    b.Property<bool>("Km");

                    b.Property<string>("Name");

                    b.Property<bool>("Person");

                    b.HasKey("RefundUnitId");

                    b.ToTable("RefundUnit");
                });

            modelBuilder.Entity("EFCore.POC.ChildComplexType.Domain.RefundType", b =>
                {
                    b.HasOne("EFCore.POC.ChildComplexType.Domain.RefundUnit", "RefundUnit")
                        .WithMany()
                        .HasForeignKey("RefundUnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
