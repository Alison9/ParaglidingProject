using Microsoft.EntityFrameworkCore.Migrations;

namespace ParaglidingProject.Data.Migrations
{
    public partial class CreateTriggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Create trigger SubscriptionIsActiveToFalse on Subscription instead of delete as begin update Subscription  set IsActive = 0 where Subscription.Year in (select Year from deleted) end");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop trigger SubscriptionIsActiveToFalse");
        }
    }
}
