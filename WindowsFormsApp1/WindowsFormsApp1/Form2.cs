using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int _ID;

        public int ID { get => _ID; set => _ID = value; }


        public void BILL(int ID)
        {

            String sql = @"SELECT  THUCUONG.TEN, CHITIETHOADON.SOLUONG, CHITIETHOADON.GIATIEN, HOADON.TONGTIEN
FROM THUCUONG,HOADON,CHITIETHOADON 
WHERE THUCUONG.IDTU = CHITIETHOADON.IDTU
AND HOADON.IDHD = CHITIETHOADON.IDHD 
AND HOADON.IDHD = " + ID;

            string sql2 = 
                @"SELECT  TOP 1 HOADON.IDHD,  HOADON.TONGTIEN,HOADON.THOIGIAN
                    FROM HOADON
                    WHERE HOADON.IDHD =" + ID;


            dbConnection db = new dbConnection();
            db.openConnection();
            DataSet ds = new DataSet();

            SqlDataAdapter adp = new SqlDataAdapter(sql, db.Con);
            adp.Fill(ds, "HoaDon");
            SqlDataAdapter adp2 = new SqlDataAdapter(sql, db.Con);
            adp2.Fill(ds, "ThucUong");
            SqlDataAdapter adp3 = new SqlDataAdapter(sql, db.Con);
            adp3.Fill(ds, "ChiTietHoaDon");

            DataSet ds2 = new DataSet();
            SqlDataAdapter a2 = new SqlDataAdapter(sql2, db.Con);
            a2.Fill(ds2, "HoaDon");



            //Khai báo chế độ xử lý báo cáo, trong trường hợp này lấy báo cáo ở local
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //Đường dẫn báo cáo
            reportViewer1.LocalReport.ReportPath = "HoaDon.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();



            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("HoaDon", ds.Tables[0]));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ChiTietHoaDon", ds.Tables[2]));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ThucUong", ds.Tables[1]));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ONLYID", ds2.Tables[0]));



            reportViewer1.RefreshReport();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_qlcfDataSet.HOADON' table. You can move, or remove it, as needed.
          
            BILL(ID);
        }
    }
}
