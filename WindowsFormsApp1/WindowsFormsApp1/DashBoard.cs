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
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApp1
{
    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        public void soluongtrongngay(string ngay)
        {
            dbConnection db = new dbConnection();
            db.openConnection();
            string sql = @"SELECT Count(*) 
                            FROM HOADON
                            WHERE  THOIGIAN >= '" + ngay + " 0:00:00' AND  THOIGIAN <= '" + ngay + " 23:59:59'";
            Int32 ID = Convert.ToInt32(db.sqlExecuteScalar(sql));


            string sql2 = @"SELECT SUM(HOADON.TONGTIEN)
                            FROM HOADON
                            WHERE  THOIGIAN >= '" + ngay + " 0:00:00' AND  THOIGIAN <= '" + ngay + " 23:59:59'";
            Int32 TONGTIEN = Convert.ToInt32(db.sqlExecuteScalar(sql2));

            label1.Text = "Tổng bán được: "+ID + "bill";
            label2.Text = "Bán được hiện tại là: " +TONGTIEN.ToString("C")+ "";
            label3.Text = ngay+"";



            db.disPose();

        }


        public void Chart(string NgayThangNam)
        {
            chart1.Series[0].Points.Clear();
            //chart2.Series[0].Points.Clear();
            dbConnection db = new dbConnection();
            List<string> Query = new List<string>();
          
            Query.Add(@"SELECT  Count(*) AS '7-12'
                        FROM HOADON
                        WHERE THOIGIAN >= '" + NgayThangNam + " 7:00:00' AND  THOIGIAN <= '" + NgayThangNam + " 12:0:0'");
            Query.Add(@"SELECT  Count(*) AS '12-19'
                        FROM HOADON
                        WHERE THOIGIAN >= '" + NgayThangNam + " 12:00:00' AND  THOIGIAN <= '" + NgayThangNam + " 19:0:0'");
            Query.Add(@"SELECT  Count(*) AS '19-0'
                        FROM HOADON
                        WHERE THOIGIAN >= '" + NgayThangNam + " 19:00:00' AND  THOIGIAN <= '" + NgayThangNam + " 23:59:59'");

            int i = 0;
            db.openConnection();
            foreach (string values in Query)
            {
                SqlCommand cmd = new SqlCommand(values, db.Con);

                SqlDataReader reader = cmd.ExecuteReader();
                string title = @"";
                switch (i)
                {
                    case 0:
                        title = "7-12";
                        break;
                    case 1:
                        title = "12-19";
                        break;
                    case 2:
                        title = "19-0";
                        break;
                }
                while (reader.Read())
                {
                    chart1.Series[0].Points.AddXY(title, reader[0].ToString());
                    //chart2.Series[0].Points.AddXY(title, reader[0].ToString());
                }
                reader.Close();
                i++;

            }
            db.closeConnection();
        }



        private void btnShow_Click(object sender, EventArgs e)
        {

            string NgayThangNam = DateTime.Now.ToString("yyyy/MM/dd");
            Chart(NgayThangNam);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            soluongtrongngay(DateTime.Now.ToString("yyyy/MM/dd"));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Chart(dateTimePicker1.Text.ToString());
                soluongtrongngay(dateTimePicker1.Text.ToString());
            }
            catch { }
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            comboBox1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            IDictionary<string, int> monthsDictionary = new Dictionary<string, int>();
            monthsDictionary.Add("Tháng 1", 1);
            monthsDictionary.Add("Tháng 2", 2);
            monthsDictionary.Add("Tháng 3", 3);
            monthsDictionary.Add("Tháng 4", 4);
            monthsDictionary.Add("Tháng 5", 5);
            monthsDictionary.Add("Tháng 6", 6);
            monthsDictionary.Add("Tháng 7", 7);
            monthsDictionary.Add("Tháng 8", 8);
            monthsDictionary.Add("Tháng 9", 9);
            monthsDictionary.Add("Tháng 10", 10);
            monthsDictionary.Add("Tháng 11", 11);
            monthsDictionary.Add("Tháng 12", 12);
            int month = 0;
            month = monthsDictionary[comboBox1.SelectedItem.ToString()] ;

            

            string Query = @"SELECT  Count(*) AS BILL
                            FROM HOADON
                            WHERE MONTH(THOIGIAN) = " + month;

            dbConnection db = new dbConnection();
            db.openConnection();
            SqlCommand sqlc = new SqlCommand(Query, db.Con);

            SqlDataReader reader = sqlc.ExecuteReader();
            chart1.Series[0].Points.Clear();
            while (reader.Read())
            {
                chart1.Series[0].Points.AddXY(comboBox1.SelectedItem.ToString(), reader[0].ToString());
               // chart2.Series[0].Points.AddXY(comboBox1.SelectedItem.ToString(), reader[0].ToString());
            }
            reader.Close();

            db.closeConnection();


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.PnlContainer.Controls.ContainsKey("DashBoard1"))
            {
                DashBoard1 dasboard1 = new DashBoard1();
                dasboard1.Dock = DockStyle.Fill;
                Form1.Instance.PnlContainer.Controls.Add(dasboard1);
            }
            Form1.Instance.PnlContainer.Controls["DashBoard1"].BringToFront();
            
        }

        private void btnSLNgay_Click(object sender, EventArgs e)
        {
            dbConnection db = new dbConnection();
            db.openConnection();
            string ngay, thang, nam;
            ngay = DateTime.Today.Day.ToString();
            thang = DateTime.Today.Month.ToString();
            nam = DateTime.Today.Year.ToString();

            SqlCommand cmd = new SqlCommand("GetThucUongTheoNgayThangNam", db.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NGAY", ngay);
            cmd.Parameters.AddWithValue("@THANG", thang);
            cmd.Parameters.AddWithValue("@NAM", nam);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.SelectCommand = cmd;
            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells ;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            chart2.Series[0].Points.Clear();
            chart2.DataSource = dt;
            chart2.Series[0].XValueMember = "TENTU";
            chart2.Series[0].YValueMembers = "DEM";
            chart2.Show();
            db.closeConnection();
            db.disPose();
            dt.Dispose();
            adp.Dispose();



        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
