using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

public class DbHelper
{
    
    private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=E.kaplan04;Database=TeknikServisDb";

   
    public DataTable GetTable(string query, NpgsqlParameter[] parameters = null)
    {
        DataTable dt = new DataTable();
        try
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Veritabanı Hatası: " + ex.Message);
        }
        return dt;
    }

    
    public int ExecuteQuery(string query, NpgsqlParameter[] parameters = null)
    {
        int rowsAffected = 0;
        try
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("İşlem Hatası: " + ex.Message);
        }
        return rowsAffected;
    }
}