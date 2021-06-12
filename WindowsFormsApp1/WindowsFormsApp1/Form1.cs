using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        static Form1 _obj;
        public static Form1 Instance
        {
            get
            {
                if (_obj == null)
                    _obj = new Form1();

                return _obj;
            }
        }

      
        public Panel PnlContainer
        {
            get { return pnlMain; }
            set { pnlMain = value; }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _obj = this;

            Board board = new Board();
            board.Dock = DockStyle.Fill;

            About ab = new About();
            ab.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(ab);
            pnlMain.Controls.Add(board);

            ab.BringToFront();
            board.SendToBack();
            showHideButton(false);
            soluongtrongngay();

        }

        private void About_Click(object sender, EventArgs e)
        {
            
            pnlMain.Controls["About"].BringToFront();
           //if (!pnlMain.Controls["About"].Visible)
           //{
           //     pnlMain.Controls["About"].Visible = true;

           //     pnlMain.Controls["About"].BringToFront();
           // }
           // else
           // {
           //     pnlMain.Controls["About"].SendToBack();
           //     pnlMain.Controls["About"].Visible = false;

           // }
            showHideButton(false);
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showHideButton(Boolean b)
        {
        
                btnXoa.Visible = b;
                button2.Visible = b;
                button3.Visible = b;

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Menu"))
            {
                Menu test = new Menu();
                test.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(test);
            }
            showHideButton(true);
            Form1.Instance.PnlContainer.Controls["Menu"].BringToFront();
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Menu"))
            {
                Menu test = new Menu();
                test.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(test);
            }
            Form1.Instance.PnlContainer.Controls["Menu"].BringToFront();
            showHideButton(true);
        }

        private void btnBoard_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("Board"))
            {
                Board board = new Board();
                board.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(board);
            }
            Form1.Instance.PnlContainer.Controls["Board"].BringToFront();
            showHideButton(false);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Control ctrl = pnlMain.Controls[0];

            if (ctrl is test)
            {
                MessageBox.Show("test");

            }
            else if (ctrl is Menu)
          
                MessageBox.Show("xxxxxxxx");
            }

       


        public void soluongtrongngay()
        {
            dbConnection db = new dbConnection();
            db.openConnection();
            string sql = @"SELECT Count(*) 
                            FROM HOADON
                            WHERE  THOIGIAN >= '" + DateTime.Now.ToString("yyyy/MM/dd") + " 0:00:00' AND  THOIGIAN <= '" + DateTime.Now.ToString("yyyy/MM/dd") + " 23:59:59'";
            Int32 ID = Convert.ToInt32(db.sqlExecuteScalar(sql));


            string sql2 = @"SELECT SUM(HOADON.TONGTIEN)
                            FROM HOADON
                            WHERE  THOIGIAN >= '" + DateTime.Now.ToString("yyyy/MM/dd") + " 0:00:00' AND  THOIGIAN <= '" + DateTime.Now.ToString("yyyy/MM/dd") + " 23:59:59'";
            Int32 TONGTIEN = Convert.ToInt32(db.sqlExecuteScalar(sql2));

            Board board = new Board();
            board.Dock = DockStyle.Fill;
            board.changeText("Bán được hiện tại là: " +ID, TONGTIEN+"");
            Form1.Instance.PnlContainer.Controls.RemoveByKey("Board");
            Form1.Instance.PnlContainer.Controls.Add(board);



            db.disPose();

        }



        public void saukhilogin()
        {
            if (false)
                btnMenu.Enabled = true;
            else
                btnMenu.Enabled = false;

        }

    }

}

