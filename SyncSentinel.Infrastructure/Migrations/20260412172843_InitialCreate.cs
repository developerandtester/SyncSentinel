using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyncSentinel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SourceSystem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExternalReference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationEventLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RoutingKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishedUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationEventLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AiInsights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsightType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    ConfidenceScore = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiInsights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AiInsights_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncidentRcaNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentRcaNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentRcaNotes_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SyncJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SourceSystem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TargetSystem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RetryCount = table.Column<int>(type: "int", nullable: false),
                    MaxRetries = table.Column<int>(type: "int", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastError = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAttemptUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SyncJobs_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AiInsights_IncidentId",
                table: "AiInsights",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentRcaNotes_IncidentId",
                table: "IncidentRcaNotes",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_Priority",
                table: "Incidents",
                column: "Priority");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_SourceSystem",
                table: "Incidents",
                column: "SourceSystem");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_Status",
                table: "Incidents",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationEventLogs_CreatedUtc",
                table: "IntegrationEventLogs",
                column: "CreatedUtc");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationEventLogs_Status",
                table: "IntegrationEventLogs",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_SyncJobs_IncidentId",
                table: "SyncJobs",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_SyncJobs_JobType",
                table: "SyncJobs",
                column: "JobType");

            migrationBuilder.CreateIndex(
                name: "IX_SyncJobs_Status",
                table: "SyncJobs",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AiInsights");

            migrationBuilder.DropTable(
                name: "IncidentRcaNotes");

            migrationBuilder.DropTable(
                name: "IntegrationEventLogs");

            migrationBuilder.DropTable(
                name: "SyncJobs");

            migrationBuilder.DropTable(
                name: "Incidents");
        }
    }
}
