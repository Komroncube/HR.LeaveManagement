using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnOnLeaveRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestCommnets",
                table: "LeaveRequests",
                newName: "RequestComments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestComments",
                table: "LeaveRequests",
                newName: "RequestCommnets");
        }
    }
}
