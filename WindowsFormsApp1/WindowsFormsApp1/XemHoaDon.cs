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
    public partial class XemHoaDon : UserControl
    {
        public XemHoaDon()
        {
            InitializeComponent();
        }

        public void loadDataGridView()
        {
            dbConnection db = new dbConnection();
            db.openConnection();

            string sql = "SELECT * FROM HOADON";
            SqlDataAdapter da = new SqlDataAdapter(sql, db.Con);
            DataSet ds = new DataSet();

            da.Fill(ds, "HOADON");
            db.closeConnection();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "HOADON";
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //            //Khai báo câu lệnh SQL
            //            String sql = @"SELECT  THUCUONG.TEN, CHITIETHOADON.SOLUONG, CHITIETHOADON.GIATIEN HOADON.TONGTIEN 
            //FROM THUCUONG,HOADON,CHITIETHOADON 
            //WHERE THUCUONG.IDTU = CHITIETHOADON.IDTU 
            //AND HOADON.IDHD = CHITIETHOADON.IDHD 
            //AND HOADON.IDHD = 2";
            //            string sql2 = "Select * from THUCUONG";
            //            string sql3 = "Select * from CHITIETHOADON";

            //            dbConnection db = new dbConnection();
            //            db.openConnection();
            //            DataSet ds = new DataSet();

            //            SqlDataAdapter adp = new SqlDataAdapter(sql, db.Con);
            //            adp.Fill(ds,"HoaDon");

            //            SqlDataAdapter adp2 = new SqlDataAdapter(sql, db.Con);
            //            adp2.Fill(ds,"ThucUong");

            //            SqlDataAdapter adp3 = new SqlDataAdapter(sql, db.Con);
            //            adp3.Fill(ds,"ChiTietHoaDon");







            ////Khai báo chế độ xử lý báo cáo, trong trường hợp này lấy báo cáo ở local
            //reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            ////Đường dẫn báo cáo
            //reportViewer1.LocalReport.ReportPath = "HoaDon.rdlc";

            //reportViewer1.LocalReport.DataSources.Clear();



            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("HoaDon", ds.Tables[0]));
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ChiTietHoaDon", ds.Tables[2]));
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ThucUong", ds.Tables[1]));




            //reportViewer1.RefreshReport();




            //}
        }

        private void XemHoaDon_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        int currentRow = -1;
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            currentRow =dataGridView1.CurrentRow.Index;
            int IDHD = int.Parse(dataGridView1.Rows[currentRow].Cells[0].Value.ToString());
           
            dbConnection db = new dbConnection();
            db.openConnection();

            string sql = @"
                            SELECT THUCUONG.TEN, SOLUONG, THUCUONG.GIATIEN
                            FROM CHITIETHOADON, THUCUONG
                            WHERE  CHITIETHOADON.IDTU = THUCUONG.IDTU AND
                            CHITIETHOADON.IDHD =" + IDHD;
            SqlDataAdapter da = new SqlDataAdapter(sql, db.Con);
            DataSet ds = new DataSet();

            da.Fill(ds, "XEMHOADON");
            db.closeConnection();
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "XEMHOADON";
            }
            catch
            {

            }

        }

        
    }
}
