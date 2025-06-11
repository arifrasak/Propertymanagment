using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Class;


namespace WebApplication1
{
    public class UserDbContext:DbContext
    {
        public DbSet<TB_USER> TB_USERS {  get; set; }
        public DbSet<TB_PROPERTY> TB_PROPERTYS { get; set; }

        public DbSet<TB_BOOKING> TB_BOOKING { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TB_USER>().ToTable("TB_USERS");
            modelBuilder.Entity<TB_PROPERTY>().ToTable("TB_PROPERTYS");
            modelBuilder.Entity<TB_BOOKING>().ToTable("TB_BOOKING");

            //Seed to Tb_user
            string usersjson = System.IO.File.ReadAllText("seedusers.json");
            List<TB_USER> tb_users = 
           System.Text.Json.JsonSerializer.Deserialize<List<TB_USER>>(usersjson);

            string propertyjson = System.IO.File.ReadAllText("seedproperties.json");
            List<TB_PROPERTY> tb_properties =
           System.Text.Json.JsonSerializer.Deserialize<List<TB_PROPERTY>>(propertyjson);

            string bookingjson = System.IO.File.ReadAllText("seedbooking.json");
            List<TB_BOOKING> tb_bookings =
           System.Text.Json.JsonSerializer.Deserialize<List<TB_BOOKING>>(bookingjson);


            foreach (TB_USER tb_user in tb_users)
             modelBuilder.Entity<TB_USER>().HasData(tb_user);

            foreach (TB_PROPERTY tb_property in tb_properties)
            modelBuilder.Entity<TB_PROPERTY>().HasData(tb_property);

            foreach (TB_BOOKING tb_booking in tb_bookings)
         modelBuilder.Entity<TB_BOOKING>().HasData(tb_booking);

        }
        public  List<TB_PROPERTY> Sp_GetBooking()
        {
            return TB_PROPERTYS.FromSqlRaw("EXECUTE [dbo].[GetBooking]").ToList();
        }
        public UserDbContext(DbContextOptions options):base(options) 
        {
            
        }
    }
}
