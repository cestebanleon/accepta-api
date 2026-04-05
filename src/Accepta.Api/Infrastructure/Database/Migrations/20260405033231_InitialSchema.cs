using System;

using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Accepta.Api.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "accepta");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "accepta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "varchar", maxLength: 128, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "merchants",
                schema: "accepta",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 128, nullable: false),
                    address = table.Column<string>(type: "varchar", maxLength: 128, nullable: true),
                    country = table.Column<string>(type: "varchar", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_merchants", x => x.id);
                    table.ForeignKey(
                        name: "fk_merchants_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "accepta",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receipts",
                schema: "accepta",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    merchant_id = table.Column<int>(type: "integer", nullable: false),
                    purchase_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    tax_amount = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    currency = table.Column<string>(type: "varchar", maxLength: 3, nullable: false),
                    alias = table.Column<string>(type: "varchar", maxLength: 128, nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_receipts", x => x.id);
                    table.ForeignKey(
                        name: "fk_receipts_merchants_merchant_id",
                        column: x => x.merchant_id,
                        principalSchema: "accepta",
                        principalTable: "merchants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_receipts_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "accepta",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receipt_items",
                schema: "accepta",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    receipt_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 128, nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_receipt_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_receipt_items_receipts_receipt_id",
                        column: x => x.receipt_id,
                        principalSchema: "accepta",
                        principalTable: "receipts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receipt_taxes",
                schema: "accepta",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    receipt_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 128, nullable: false),
                    amount = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_receipt_taxes", x => x.id);
                    table.ForeignKey(
                        name: "fk_receipt_taxes_receipts_receipt_id",
                        column: x => x.receipt_id,
                        principalSchema: "accepta",
                        principalTable: "receipts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_merchants_user_id",
                schema: "accepta",
                table: "merchants",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_receipt_items_receipt_id",
                schema: "accepta",
                table: "receipt_items",
                column: "receipt_id");

            migrationBuilder.CreateIndex(
                name: "ix_receipt_taxes_receipt_id",
                schema: "accepta",
                table: "receipt_taxes",
                column: "receipt_id");

            migrationBuilder.CreateIndex(
                name: "ix_receipts_merchant_id",
                schema: "accepta",
                table: "receipts",
                column: "merchant_id");

            migrationBuilder.CreateIndex(
                name: "ix_receipts_user_id",
                schema: "accepta",
                table: "receipts",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receipt_items",
                schema: "accepta");

            migrationBuilder.DropTable(
                name: "receipt_taxes",
                schema: "accepta");

            migrationBuilder.DropTable(
                name: "receipts",
                schema: "accepta");

            migrationBuilder.DropTable(
                name: "merchants",
                schema: "accepta");

            migrationBuilder.DropTable(
                name: "users",
                schema: "accepta");
        }
    }
}