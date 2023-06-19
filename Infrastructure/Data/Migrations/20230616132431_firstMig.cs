using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerSerial = table.Column<int>(type: "int", nullable: false),
                    CustomerArName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CustomerEnName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CashDiscPercent = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "DefItems",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemSerial = table.Column<int>(type: "int", nullable: false),
                    ItemArName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ItemEnName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Vat = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefItems", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "DefStores",
                columns: table => new
                {
                    StoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreSerial = table.Column<int>(type: "int", nullable: false),
                    StoreArName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    StoreEnName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefStores", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "TrxInvoiceHeads",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceSerial = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<int>(type: "int", nullable: false),
                    TotalbeforeDiscount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    TotalAfterDiscount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    TotalTax = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    TotalInvoiceNet = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    InvoiceDescription = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrxInvoiceHeads", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_TrxInvoiceHeads_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrxInvoiceHeads_DefStores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "DefStores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrxInvoiceDetails",
                columns: table => new
                {
                    InvoiceDetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    TotalValue = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    CashDiscPercent = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    TotalAfterDiscount = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    TaxPercent = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    TotalInvoiceNet = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrxInvoiceDetails", x => x.InvoiceDetID);
                    table.ForeignKey(
                        name: "FK_TrxInvoiceDetails_DefItems_ItemID",
                        column: x => x.ItemID,
                        principalTable: "DefItems",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrxInvoiceDetails_TrxInvoiceHeads_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "TrxInvoiceHeads",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrxInvoiceDetails_InvoiceID",
                table: "TrxInvoiceDetails",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_TrxInvoiceDetails_ItemID",
                table: "TrxInvoiceDetails",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_TrxInvoiceHeads_CustomerID",
                table: "TrxInvoiceHeads",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_TrxInvoiceHeads_StoreID",
                table: "TrxInvoiceHeads",
                column: "StoreID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrxInvoiceDetails");

            migrationBuilder.DropTable(
                name: "DefItems");

            migrationBuilder.DropTable(
                name: "TrxInvoiceHeads");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DefStores");
        }
    }
}
