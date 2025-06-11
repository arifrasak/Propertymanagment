using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Sp_GetBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string Sp_GetBooking = @"
create procedure [dbo].[GetBooking]
as begin
select * from [dbo].[TB_PROPERTYS] 
end
";
migrationBuilder.Sql(Sp_GetBooking);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
