using Microsoft.Data.SqlClient;
using System.Data;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.Class
{
    public class PropertyService
    {
        private readonly string connectionString;
        TB_PROPERTY property = new TB_PROPERTY();

        public PropertyService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public DataTable ViePropertylist()
        {
            DataTable objcusdt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sql = "select * from TB_PROPERTYS where ISAVILABLE=1";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(objcusdt);
                }
                foreach (DataRow dr in objcusdt.Rows)
                {
                    property.NAME = dr["NAME"].ToString();
                    property.LOCATION = dr["LOCATION"].ToString();
                    property.PRICE = Convert.ToDecimal(dr["PRICE"]);
                    property.ISAVILABLE = Convert.ToBoolean(dr["ISAVILABLE"]);
                }
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
            return objcusdt;
        }
        public bool Addproperty()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Addproperty", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@NAME", property.NAME);
                        cmd.Parameters.AddWithValue("@LOCATION", property.LOCATION);
                        cmd.Parameters.AddWithValue("@PRICE", property.PRICE);

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
        public bool Editproperty()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Sp_Editproperty", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@NAME", property.NAME);
                        cmd.Parameters.AddWithValue("@LOCATION", property.LOCATION);
                        cmd.Parameters.AddWithValue("@PRICE", property.PRICE);
                        cmd.Parameters.AddWithValue("@ID", property.ID);
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
