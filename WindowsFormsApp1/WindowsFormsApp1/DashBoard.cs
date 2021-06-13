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
            chart2.Series[0].Points.Clear();
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
                    chart2.Series[0].Points.AddXY(title, reader[0].ToString());
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
                
            while (reader.Read())
            {
                chart2.Series[0].Points.AddXY(comboBox1.SelectedItem.ToString(), reader[0].ToString());
               // chart2.Series[0].Points.AddXY(comboBox1.SelectedItem.ToString(), reader[0].ToString());
            }
            reader.Close();

            db.closeConnection();


        }
    }
}
