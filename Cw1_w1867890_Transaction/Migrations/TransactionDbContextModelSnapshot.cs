// <auto-generated />
using System;
using Cw1_w1867890_Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cw1_w1867890_Transaction.Migrations
{
    [DbContext(typeof(TransactionDbContext))]
    partial class TransactionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cw1_w1867890_Transaction.Transaction", b =>
                {
                    b.Property<int>("TranId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("TranAmount")
                        .HasColumnType("float");

                    b.Property<int>("TranCatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TranDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TranDescription")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("TranRecurring")
                        .HasColumnType("bit");

                    b.HasKey("TranId");

                    b.ToTable("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
