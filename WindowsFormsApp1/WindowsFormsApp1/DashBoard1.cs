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
    public partial class DashBoard1 : UserControl
    {
        public DashBoard1()
        {
            InitializeComponent();
        }

        int _CurrentPos;
        List<string> listID;



        public void GetHoaDonTheoNgayThangNam(string ngay, string thang, string nam)
        {

            dbConnection db = new dbConnection();
            db.openConnection();
            SqlCommand cmd = new SqlCommand("GetHoaDonTheoNgayThangNam", db.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NGAY", ngay);
            cmd.Parameters.AddWithValue("@THANG", thang);
            cmd.Parameters.AddWithValue("@NAM", nam);

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.SelectCommand = cmd;
            adp.Fill(ds, "HoaDon");


            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsGetHoaDon", ds.Tables[0]));
            reportViewer1.RefreshReport();

        }

        public void GetHoaDon(int ID)
        {

            dbConnection db = new dbConnection();
            db.openConnection();
            SqlCommand cmd = new SqlCommand("GetHoaDon", db.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDHD", ID);

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.SelectCommand = cmd;
            adp.Fill(ds, "HoaDon");


            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsGetHoaDon", ds.Tables[0]));
            reportViewer1.RefreshReport();

        }



        private void btnShowReport_Click(object sender, EventArgs e)
        {

            dbConnection db = new dbConnection();
            db.openConnection();
            string ngay,thang,nam;
            ngay = DateTime.Today.Day.ToString();
            thang = DateTime.Today.Month.ToString();
            nam = DateTime.Today.Year.ToString();
            //string getID = @"SELECT IDHD
            //                    FROM HOADON
            //                    WHERE MONTH(HOADON.THOIGIAN) = " + thang
            //                    + " AND DAY(HOADON.THOIGIAN) = " + ngay
            //;
            //SqlCommand sqlCmd = new SqlCommand(getID, db.Con);


            SqlCommand cmd = new SqlCommand("GetHoaDonTheoNgayThangNam", db.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NGAY", ngay);
            cmd.Parameters.AddWithValue("@THANG", thang);
            cmd.Parameters.AddWithValue("@NAM", nam);

            SqlDataReader sqlReader = cmd.ExecuteReader();
            if (listID is null)
                listID = new List<string>();
            else
                listID.Clear();
            _CurrentPos = 0;

            while (sqlReader.Read() ) 
            {
                string values = sqlReader.GetValue(0).ToString();
                if (!listID.Contains(values))
                    listID.Add(values);
            }
            sqlReader.Close();
            cmd.Dispose();
            _CurrentPos = 0;

            btnL.Enabled = false;
            btnR.Enabled = true;
            GetHoaDon(int.Parse(listID[0].ToString()));
            db.closeConnection();
            db.disPose();
        }

        private void btnL_Click(object sender, EventArgs e)
        {

            _CurrentPos--;
            if (_CurrentPos == 0)
            {
                btnL.Enabled = false;
                GetHoaDon(int.Parse(listID[_CurrentPos]));
                return;
            }
            else
            {
                btnR.Enabled = true;
                GetHoaDon(int.Parse(listID[_CurrentPos]));
            }
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            _CurrentPos++;
            if (_CurrentPos == listID.Count - 1)
            {
                btnR.Enabled = false;
                GetHoaDon(int.Parse(listID[_CurrentPos]));
                return;
            }
            else
            {
                btnL.Enabled = true;
                GetHoaDon(int.Parse(listID[_CurrentPos]));
            }

        }
    }
}
