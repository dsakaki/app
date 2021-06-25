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

            SqlCommand cmd = new SqlCommand("SELECT * FROM DANGNHAP WHERE TAIKHOAN=@val1",db.Con);
            cmd.Parameters.AddWithValue("@val1", tk);

            DataTable tb = new DataTable();
            db.openConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(tb);
            if (tb.Rows.Count == 1)
            {
                byte[] hash = tb.Rows[0].Field<byte[]>("MATKHAU");
                byte[] salt = tb.Rows[0].Field<byte[]>("SALT");
;
                if (PasswordHashUtils.VerifyHashPassword(
                                  mk,
                                  Convert.ToBase64String(hash),
                                  Convert.ToBase64String(salt)))
                MessageBox.Show("Đăng nhập thành công username " + tk, "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel3.Hide();
                Form1.Instance.Username = tk;
                Form1.Instance.initForm();
                label2.Text = "Tài khoản: "+tk;
                label2.Font = new System.Drawing.Font(label2.Font.FontFamily.Name, 30);
            }
            else
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không chính xác!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
            db.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("DashBoard"))
            {
                DashBoard dashboard = new DashBoard();
                dashboard.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(dashboard);

            }
            Form1.Instance.PnlContainer.Controls["DashBoard"].BringToFront();
            //Form1.Instance.PnlContainer.Controls["XemHoaDon"].BringToFront();
            //if (!Form1.Instance.PnlContainer.Controls.ContainsKey("XemHoadon"))
            //{
            //    XemHoaDon xemhoadon = new XemHoaDon();
            //    xemhoadon.Dock = DockStyle.Fill;
            //    Form1.Instance.PnlContainer.Controls.Add(xemhoadon);

            //}
            //Form1.Instance.PnlContainer.Controls["XemHoaDon"].BringToFront();
        }


        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPass.Text = txtPass.Text = "";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("DashBoard"))
            {
                DashBoard dashboard = new DashBoard();
                dashboard.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(dashboard);

            }
            Form1.Instance.PnlContainer.Controls["DashBoard"].BringToFront();
            //Form1.Instance.PnlContainer.Controls["XemHoaDon"].BringToFront();
            //if (!Form1.Instance.PnlContainer.Controls.ContainsKey("XemHoadon"))
            //{
            //    XemHoaDon xemhoadon = new XemHoaDon();
            //    xemhoadon.Dock = DockStyle.Fill;
            //    Form1.Instance.PnlContainer.Controls.Add(xemhoadon);

            //}
            //Form1.Instance.PnlContainer.Controls["XemHoaDon"].BringToFront();
        }
    }
}
