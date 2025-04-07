using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "58ec4bbf-4913-4dc1-96b7-381159ce0878",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa69aeef-abe7-4014-82d4-5ad653a7cb54", "AQAAAAIAAYagAAAAECdIBKZfi4z6aOXJzj0QfBmT4rZ4u4MUUuVpAxSvpcJrki2hWz/ZwvW3gtmuI9oREg==", "50655cd3-0af4-4549-84f0-57f17d96f1ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "626b8c7f-f4d4-4467-bb37-570f1aa6fd77",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2866e8f-7f5c-4940-a81b-5c9afbe5554a", "AQAAAAIAAYagAAAAENRQGCT+AnEhC2tjkQ0uWCI30AUaBIOIL0JPGJnX279r8+iopdFqJ3w992SeN3J5vQ==", "34bed44d-0982-4caf-b2fb-be03f44dc381" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a86582e6-8511-4b78-b548-e17a2eaf0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25032349-409d-4e98-8a40-f97db7f9f37a", "AQAAAAIAAYagAAAAEJoiQdm0y5IZpZF3BLXERkWstuy+8EU8jUfOtDnpLcyoqiwq6wIke/LyLQcrmxpFCw==", "e14da933-e6c7-44b3-8045-c82cd1c52292" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e452e625-327a-4bf2-9540-3db6577ab68f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19caa602-33ca-4e29-9dfd-d04f700634e4", "AQAAAAIAAYagAAAAEJkRk/RFb1ZVrpUzqe2Wzx4XJJV3xK97u7+8jCynLmaDJeg+d/Ec3297gFtTQyZsdA==", "dcc112b5-8bf7-4949-864d-38aaa190377e" });

            migrationBuilder.UpdateData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: "PROG-1001",
                column: "LastUpdated",
                value: new DateTime(2025, 4, 7, 0, 12, 7, 564, DateTimeKind.Utc).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: "PROG-1002",
                column: "LastUpdated",
                value: new DateTime(2025, 4, 7, 0, 12, 7, 564, DateTimeKind.Utc).AddTicks(673));

            migrationBuilder.UpdateData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: "PROG-1003",
                column: "LastUpdated",
                value: new DateTime(2025, 4, 7, 0, 12, 7, 564, DateTimeKind.Utc).AddTicks(677));

            migrationBuilder.UpdateData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: "PROG-1004",
                column: "LastUpdated",
                value: new DateTime(2025, 4, 7, 0, 12, 7, 564, DateTimeKind.Utc).AddTicks(679));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "58ec4bbf-4913-4dc1-96b7-381159ce0878",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61298506-c046-4d84-b997-ab42c567aa4f", "AQAAAAIAAYagAAAAEE1XiDAgXPoUcoTC/ef7nKgX4vnn2CMxThSrzVVHO+KXvYiLEmFhGZ6vA8OTLpShQQ==", "21b01438-a084-4546-badc-e382c98e289a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "626b8c7f-f4d4-4467-bb37-570f1aa6fd77",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68bc0cb2-1d37-4326-8a4a-5cc9ca93e012", "AQAAAAIAAYagAAAAEG/iLvLW6gFXqCXfEawSpU5VZ90fpgVgkdxbw7NyzYPIgYfowKp5ffmfBiEpdetYKQ==", "54ddcc33-3090-4a9d-82cb-5561e0a54115" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a86582e6-8511-4b78-b548-e17a2eaf0d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc0cc525-bc2c-4b99-97e1-0b6e3fa5dbde", "AQAAAAIAAYagAAAAEEzgmriyZaYGkCo2FI5VDwIeR9ggLbPgycech2b0BpnK4MAr6Ax1pNVGn+8+om3T/g==", "bb20bac4-a8d3-4d89-a2fa-ce20953eb4f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e452e625-327a-4bf2-9540-3db6577ab68f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35ead44c-1e8e-4b52-a128-c8f6455b94b0", "AQAAAAIAAYagAAAAEHuafvNSE3Gim9cchwCQlm+DtTA2wCh+12+zCON1B5IQAAvKK/5GDr06Qgg5kp/32g==", "38ff0eaa-3b25-45b7-ba39-133e55da5975" });

            migrationBuilder.UpdateData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: "PROG-1001",
                column: "LastUpdated",
                value: new DateTime(2025, 4, 6, 23, 44, 15, 361, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: "PROG-1002",
                column: "LastUpdated",
                value: new DateTime(2025, 4, 6, 23, 44, 15, 361, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: "PROG-1003",
                column: "LastUpdated",
                value: new DateTime(2025, 4, 6, 23, 44, 15, 361, DateTimeKind.Utc).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: "PROG-1004",
                column: "LastUpdated",
                value: new DateTime(2025, 4, 6, 23, 44, 15, 361, DateTimeKind.Utc).AddTicks(7056));
        }
    }
}
