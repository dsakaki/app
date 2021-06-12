using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
        }

        private void About_Load(object sender, EventArgs e)
        {
            version ver = new version();
            label1.Text += ": " + ver.Version.ToString() + "\r\nTime update: " + ver.Date.ToShortDateString() ;
           
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
        dbConnection db = new dbConnection();
        private void button2_Click(object sender, EventArgs e)
        {

                string tk = txtUserName.Text.Trim();
                string mk = txtPass.Text.Trim();
                string strSQL = "SELECT username FROM login WHERE username='" + tk + "' and psswd='" + mk + "'";
                DataTable tb = new DataTable();
                db.openConnection();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, db.Con);
                da.Fill(tb);
                if (tb.Rows.Count == 1)
                {

                    MessageBox.Show("Đăng nhập thành công username " + tk, "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panel3.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không chính xác!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            db.Con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("XemHoadon"))
            {
                XemHoaDon xemhoadon = new XemHoaDon();
                xemhoadon.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(xemhoadon);

            }
            Form1.Instance.PnlContainer.Controls["XemHoaDon"].BringToFront();
        }


        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }
    }
}
