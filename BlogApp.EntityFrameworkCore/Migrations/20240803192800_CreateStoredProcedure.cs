using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class CreateStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE GetRecentlyPublishedArticles
                  AS
                  BEGIN
            SELECT *
            FROM Articles a
            WHERE a.Status = 'Published' AND a.PublicationDate >= DATEADD(day, -30, GETDATE())
            ORDER BY a.PublicationDate DESC
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            DROP PROCEDURE IF EXISTS [dbo].[GetRecentlyPublishedArticles]
        ");
        }
    }
}
