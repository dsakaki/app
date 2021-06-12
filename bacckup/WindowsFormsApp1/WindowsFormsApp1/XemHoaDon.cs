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
            
        }

        private void XemHoaDon_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        int currentRow = -1;
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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

        
    }
}
