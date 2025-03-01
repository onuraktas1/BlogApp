using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class BlogRaytingTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var result = migrationBuilder.Sql($"Create Trigger AddBlogInRaytingTable On Blogs After Insert As Declare @ID int Select @ID=Id from inserted Insert BlogRaytings (BlogID,TotalScore,RaytingCount) Values(@ID,0,0)");

            var result2 = migrationBuilder.Sql($"Create Trigger AddScoreInComment On Comments After Insert As Declare @ID int Declare @Score int Declare @RaytingCount int Select @ID=BlogId,@Score=Score from inserted Update BlogRaytings Set TotalScore = TotalScore+@Score, RaytingCount +=1 where BlogID=@ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DROP TRIGGER IF EXISTS AddBlogInRaytingTable");

            migrationBuilder.Sql("DROP TRIGGER IF EXISTS AddScoreInComment");
        }
    }
}
