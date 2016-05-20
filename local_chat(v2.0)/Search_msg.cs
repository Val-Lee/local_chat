using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace local_chat_v2.__
{
    public partial class Search_msg : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Val-Lee\2kurs\kursa4\local_chat\local_chat(v2.0)\LocalDB_local_chat.mdf;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt = new DataTable();
        public Search_msg()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string txt;
            txt = searchText.Text + "%";          
            try
            {
                con.Open();
                string cmdText = "select * from local_chat where Message like '" + txt + "' ";
                da = new SqlDataAdapter(cmdText, con);
                ds = new DataSet();
                da.Fill(ds, "local_chat");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception q)
            {
                MessageBox.Show(q.Message);

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
    }
}
