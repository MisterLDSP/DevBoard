using Microsoft.EntityFrameworkCore.Migrations;

namespace DevBoard.Server.Migrations
{
    public partial class SubWorks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Works_ParentWorkId",
                table: "Works");

            migrationBuilder.RenameColumn(
                name: "ParentWorkId",
                table: "Works",
                newName: "WorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_ParentWorkId",
                table: "Works",
                newName: "IX_Works_WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Works_WorkId",
                table: "Works",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Works_WorkId",
                table: "Works");

            migrationBuilder.RenameColumn(
                name: "WorkId",
                table: "Works",
                newName: "ParentWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_WorkId",
                table: "Works",
                newName: "IX_Works_ParentWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Works_ParentWorkId",
                table: "Works",
                column: "ParentWorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
