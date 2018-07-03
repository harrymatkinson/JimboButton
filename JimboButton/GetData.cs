using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimboButton
{
    public class GetData : NumberGeneration
    {

        // extract a quote from the data based on the generated ID
        public string GetQuote(string sqlQuery)
        {
            using (SqlConnection con = new SqlConnection((App.Current as App).ConnectionString))
            {
                con.Open();

                // select the fields that are needed to display, for only the current quote ID
                using (SqlCommand cmd = new SqlCommand(sqlQuery))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        // using a SQL parameter protects against SQL injection
                        cmd.Parameters.AddWithValue("@QuoteID", GenerateID());
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            con.Close();
                            string quote;
                            quote = (string)dt.Rows[0][0];
                            return quote;
                        }
                    }
                }
            }
        }
    }
}
