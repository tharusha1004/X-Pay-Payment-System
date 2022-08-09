using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Final_GAD_CW2
{
    class IOdata
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        public IOdata()
        {
            con = new SqlConnection("Data Source=LAPTOP-K3UER6UD;Initial Catalog=XPay_Payment_System;Integrated Security=True");
        }
        public int CustomerInsert(string query)
        {
            con.Open();
            cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int DealerInsert(string query)
        {
            con.Open();
            cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
            /*
            //reducing Account Balance
            string accountNo = (txt_accno.Text);
            AccountBalanceLogic AB = new AccountBalanceLogic();
            int x = AB.calBal(tnsamt, accountNo);
            if (x == 0)
            {
                MessageBox.Show("Your Account Number Is Invalid!");
                // call registration class
                con.Close();
            }
            else
            {
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i == 1)
                    MessageBox.Show(this, "Your Transaction Is Done !", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }*/
        }

        public DataTable DataView(string query)
        {
            con.Open();
            da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
