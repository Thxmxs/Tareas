using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasMVC.Migrations
{
    /// <inheritdoc />
    public partial class AdminRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF NOT EXISTS (select Id from AspNetRoles where Id = '688d8c05-2d21-4c1e-804a-287dbbb5d628')
BEGIN
	INSERT AspNetRoles (Id,Name,NormalizedName)
	Values ('688d8c05-2d21-4c1e-804a-287dbbb5d628','admin','ADMIN')
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles Where Id = '688d8c05-2d21-4c1e-804a-287dbbb5d628'");

        }
    }
}
