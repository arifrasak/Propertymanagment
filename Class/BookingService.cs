using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplication1.Class
{
    public class BookingService
    {
        private readonly string connectionString;
        TB_BOOKING booking = new TB_BOOKING();

        public BookingService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool AddBooking()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_AddBooking", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PROPERTYID", booking.PROPERTYID);
                        cmd.Parameters.AddWithValue("@USERID", booking.USERID);
                        cmd.Parameters.AddWithValue("@BOOKINGDATE", booking.BOOKINGDATE);
                        cmd.Parameters.AddWithValue("@STATUS", booking.STATUS);
                        con.Open();
                        SqlTransaction transaction = con.BeginTransaction();
                        cmd.Transaction = transaction;
                        try
                        {
                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return false;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
