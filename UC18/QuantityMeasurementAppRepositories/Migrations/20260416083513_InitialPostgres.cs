using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuantityMeasurementAppRepositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quantity_measurements_tables_conversion",
                columns: table => new
                {
                    entity_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entity_user_id = table.Column<long>(type: "bigint", nullable: false),
                    entity_result_value = table.Column<double>(type: "double precision", nullable: false),
                    entity_measurement_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    entity_operation = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    entity_second_unit = table.Column<string>(type: "text", nullable: true),
                    entity_created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    entity_updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    entity_is_error = table.Column<bool>(type: "boolean", nullable: false),
                    entity_error_message = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    entity_first_value = table.Column<double>(type: "double precision", nullable: false),
                    entity_first_unit = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    entity_second_value = table.Column<double>(type: "double precision", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quantity_measurements_tables_conversion", x => x.entity_id);
                });

            migrationBuilder.CreateTable(
                name: "users_authenication_and_authorization",
                columns: table => new
                {
                    entity_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entity_email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    entity_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    entity_password_hash = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created_entity_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_active_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_authenication_and_authorization", x => x.entity_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quantity_measurements_is_error",
                table: "quantity_measurements_tables_conversion",
                column: "entity_is_error");

            migrationBuilder.CreateIndex(
                name: "IX_quantity_measurements_measurement_type",
                table: "quantity_measurements_tables_conversion",
                column: "entity_measurement_type");

            migrationBuilder.CreateIndex(
                name: "IX_quantity_measurements_operation",
                table: "quantity_measurements_tables_conversion",
                column: "entity_operation");

            migrationBuilder.CreateIndex(
                name: "IX_quantity_measurements_user_id",
                table: "quantity_measurements_tables_conversion",
                column: "entity_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users_authenication_and_authorization",
                column: "entity_email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quantity_measurements_tables_conversion");

            migrationBuilder.DropTable(
                name: "users_authenication_and_authorization");
        }
    }
}
