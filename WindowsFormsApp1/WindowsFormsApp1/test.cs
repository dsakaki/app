using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class test : UserControl
    {
        public test()
        {
            InitializeComponent();
            
        }
        int _tongtien;
        public int tongtien
        {
            get { return _tongtien; }
            set { _tongtien = value; }
        }

        internal HoaDon Hoadon { get => hoadon; set => hoadon = value; }

        HoaDon hoadon;
        public void initBill()
        {
            Hoadon = new HoaDon();

        }


        public void label2Reset()
        {


        }

        public void reset()
        {
            tiennhap = 0;
            label2.Text = 0 +"";
        }
      

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void test_Load(object sender, EventArgs e)
        {

            label1.Text = _tongtien + "";
            ButtonLoad();
            btn_Thanhtoan.Enabled = false;


        }
      

        private void btn_MouseHover(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.ForeColor = Color.Red;
            button.BackColor = System.Drawing.Color.FromArgb(71, 20,180);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.ForeColor = Color.White;
            button.BackColor = System.Drawing.Color.FromArgb(99, 20, 180);

        }
        private void ButtonClicKDuTien(object sender, EventArgs e)
        {

            tiennhap = _tongtien;
            label2.Text = tiennhap + "";

            label3.Text = "ĐỦ TIỀN";
            btn_Thanhtoan.Enabled = true;
        }
        

        private void ButtonLoad()
        { 
            // Form1.Instance.PnlContainer.Controls["panel1"].Hide();

            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            //flowLayoutPanel1.Padding = new Padding(80, 10, 200, 0);
            flowLayoutPanel1.Padding = new Padding(80, 10, 200, 0);
            List<Button> buttonList = new List<Button>();


            Button btn1 = new Button();
            btn1.Name = "1k";
            btn1.Text = "1000";
            btn1.Tag = "1000";

            Button btn2 = new Button();
            btn2.Name = "2k";
            btn2.Text = "2000";
            btn2.Tag = "2000";

            Button btn3 = new Button();
            btn3.Name = "5k";
            btn3.Text = "5000";
            btn3.Tag = "5000";

            Button btn4 = new Button();
            btn4.Name = "10k";
            btn4.Text = "10000";
            btn4.Tag = "10000";

            Button btn5 = new Button();
            btn5.Name = "20k";
            btn5.Text = "20000";
            btn5.Tag = "20000";

            Button btn6 = new Button();
            btn6.Name = "50k";
            btn6.Text = "50000";
            btn6.Tag = "50000";

            Button btn7 = new Button();
            btn7.Name = "100k";
            btn7.Text = "100000";
            btn7.Tag = "100000";

            Button btn8 = new Button();
            btn8.Name = "200k";
            btn8.Text = "200000";
            btn8.Tag = "200000";


            Button btn9 = new Button();
            btn9.Name = "500k";
            btn9.Text = "500000";
            btn9.Tag = "500000";

            buttonList.Add(btn1);
            buttonList.Add(btn2);
            buttonList.Add(btn3);
            buttonList.Add(btn4);
            buttonList.Add(btn5);
            buttonList.Add(btn6);
            buttonList.Add(btn7);
            buttonList.Add(btn8);
            buttonList.Add(btn9);

            foreach (Button b in buttonList)
            {
                b.Font = new Font("Arial", 30);
                b.ForeColor = Color.White;
                b.Size = new System.Drawing.Size(250, 150);
                b.Click += ButtonClickHandler;
                b.MouseHover += btn_MouseHover;
                b.MouseLeave += btn_MouseLeave;
                flowLayoutPanel1.Controls.Add(b);

            }
            Button bt = new Button();
            bt.Text = "ĐỦ TIỀN";
            bt.Font = new Font("Arial", 30);
            bt.ForeColor = Color.White;
            bt.Size = new System.Drawing.Size(760, 80);
            bt.Click += ButtonClicKDuTien;
            bt.MouseHover += btn_MouseHover;
            bt.MouseLeave += btn_MouseLeave;
            flowLayoutPanel1.Controls.Add(bt);

        }

        int tiennhap = 0;
        private void ButtonClickHandler(object sender, EventArgs e)
        {
            
            var button = (Button)sender;
            int tmptien = int.Parse(button.Tag.ToString());
            tiennhap += tmptien;
            label2.Text = tiennhap + "";


            if (int.Parse(label2.Text) >= int.Parse(label1.Text))
                btn_Thanhtoan.Enabled = true;
            int tienthoi = tiennhap - _tongtien;
            if (tienthoi < 0)
                label3.Text = "CHƯA ĐỦ TIỀNNNNNNNNNN";
            else
            label3.Text = tienthoi + "";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btn_Thanhtoan_Click(object sender, EventArgs e)
        {

            dbConnection db = new dbConnection();
            db.openConnection();

            string query = "INSERT INTO HOADON";
            query += " VALUES (@TONGTIEN,@TIENDUA,@TIENTRA,@THOIGIAN)";

           
            SqlCommand myCommand = new SqlCommand(query, db.Con);
            myCommand.Parameters.AddWithValue("@TONGTIEN", hoadon.TONGTIEN);
            myCommand.Parameters.AddWithValue("@TIENDUA", tiennhap);
            myCommand.Parameters.AddWithValue("@TIENTRA", tiennhap - hoadon.TONGTIEN);
            myCommand.Parameters.AddWithValue("@THOIGIAN", DateTime.Now);
            myCommand.ExecuteNonQuery();

            Int32 ID = Convert.ToInt32(db.sqlExecuteScalar("SELECT Count(*) FROM HOADON"));
            if (ID == 0)
                ID++;
            try
            {

                foreach (ChiTietHoaDon b in hoadon.CTHD)
                {

                    string querySUBBILL = @"INSERT INTO CHITIETHOADON VALUES('" +
                                    ID + "','" +
                                    b.IDTU + "','" +
                                    b.SOLUONG + "','" +
                                    b.GIATIEN + "')";
                    db.sqlExcuteNonQuery(querySUBBILL);

                }

                db.closeConnection();
                MessageBox.Show("OK");
            }
            catch
            {
                MessageBox.Show("FAIL");
            
            }

            label2.Text = 0+"";
            tongtien = 0;
            tiennhap = 0;

            Form1.Instance.soluongtrongngay();

            Form2 x = new Form2();
            x.ID = ID;
            x.Show();

            Menu menu = new Menu();
            menu.Dock = DockStyle.Fill;

            Form1.Instance.PnlContainer.Controls.RemoveByKey("Menu");
            Form1.Instance.PnlContainer.Controls.Add(menu);
            Form1.Instance.PnlContainer.Controls["Menu"].BringToFront();

        }
    }
}
