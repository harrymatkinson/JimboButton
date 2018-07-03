using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimboButton
{
    public class NumberGeneration
    {
        public int GenerateID()
        {
            Random rnd = new Random();
            // the random parameters need to be the min and max quote IDs from the data
            // note that the second (top) parameter of Random.Next is exclusive, so this needs to be the max ID + 1
            int ID = rnd.Next(MinID(), MaxID() + 1);
            return ID;
        }

        // get the lowest quote ID value from the data
        private int MinID()
        {
            using (SqlConnection con = new SqlConnection((App.Current as App).ConnectionString))
            {
                con.Open();

                // select the fields that are needed to display, for only the current quote ID
                using (SqlCommand cmd = new SqlCommand("SELECT MIN(QuoteID) FROM Quotes"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            con.Close();
                            int minID = (int)dt.Rows[0][0];
                            return minID;
                        }
                    }
                }
            }
        }

        // get the highest quote ID value from the data
        private int MaxID()
        {
            using (SqlConnection con = new SqlConnection((App.Current as App).ConnectionString))
            {
                con.Open();

                // select the fields that are needed to display, for only the current quote ID
                using (SqlCommand cmd = new SqlCommand("SELECT MAX(QuoteID) FROM Quotes"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            con.Close();
                            int maxID = (int)dt.Rows[0][0];
                            return maxID;
                        }
                    }
                }
            }
        }
    }
}
