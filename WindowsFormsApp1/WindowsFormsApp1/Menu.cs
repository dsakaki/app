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
    public partial class Menu : UserControl
    {
		int _tongtien = 0;
		public Menu()
        {
            InitializeComponent();
        }


		List<ChiTietHoaDon> cthd = new List<ChiTietHoaDon>();
		private void ButtonClickHandler(object sender, EventArgs e)
		{

			var button = (Button)sender;
			ChiTietHoaDon tmp = new ChiTietHoaDon();
			tmp.IDTU = int.Parse(button.Name);
			tmp.GIATIEN = int.Parse(button.Tag.ToString());
			tmp.TENTU = button.Text;

			foreach (DataGridViewRow row in dataGridView1.Rows)
				if (!(row.Cells[0].Value == null) && row.Cells[0].Value.ToString().Equals(tmp.TENTU))
				{
					row.Cells[1].Value = int.Parse(row.Cells[1].Value.ToString()) + 1;
					row.Cells[2].Value = int.Parse(row.Cells[1].Value.ToString()) * tmp.GIATIEN;
					_tongtien += (int)tmp.GIATIEN;
					label1.Text = "TỔNG TIỀN= " + _tongtien.ToString();
					return;
				}

			dataGridView1.Rows.Add(button.Text, "1", button.Tag + "");
			cthd.Add(tmp);
			_tongtien += int.Parse(tmp.GIATIEN.ToString());

			label1.Text = "TỔNG TIỀN= " + _tongtien.ToString();

		}




		private void Menu_Load(object sender, EventArgs e)
		{
			

			flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
			flowLayoutPanel1.Padding = new Padding(0, 20, 0, 0);

			DataSet dataSet = new DataSet("THUCUONG");
			dbConnection dbConnection = new dbConnection();
			string selectCommandText = "SELECT * FROM THUCUONG";
			dbConnection.openConnection();
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, dbConnection.Con))
			{
				sqlDataAdapter.Fill(dataSet);
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					//???????????
					ThucUong thucUong = new ThucUong();
					thucUong.IDTU = int.Parse(row["IDTU"].ToString());
					thucUong.TEN = row["TEN"].ToString();
					thucUong.GIATIEN = int.Parse(row["GIATIEN"].ToString());
					//??????????

					Button button = new Button();
					button.Name = thucUong.IDTU.ToString();
					button.Text = thucUong.TEN;
					button.Tag = (thucUong.GIATIEN.ToString() ?? "");
					button.Size = new Size(150, 100);
					button.Click += ButtonClickHandler;
					button.Font = new Font("Arial", 15f);
					button.ForeColor = Color.White;
					flowLayoutPanel1.Controls.Add(button);
				}
			}
			dbConnection.closeConnection();


		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (dataGridView1.Rows.Count == 0)
			{
				MessageBox.Show("Chưa chọn món");
			}
			else
			{

				test test = new test();
				test.Dock = DockStyle.Fill;
				test.tongtien = _tongtien;
				test.initBill();
				int tmptongtien = 0;


				for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
				{
					
					cthd[rows].SOLUONG = int.Parse(dataGridView1.Rows[rows].Cells[1].Value.ToString());
					cthd[rows].GIATIEN = int.Parse(dataGridView1.Rows[rows].Cells[2].Value.ToString());
						
				}


				HoaDon hd = new HoaDon(cthd);
				foreach (ChiTietHoaDon c in cthd)
					tmptongtien += c.GIATIEN;
				hd.TONGTIEN = tmptongtien;
				test.Hoadon = hd;

				if (!Form1.Instance.PnlContainer.Controls.ContainsKey("test"))
					Form1.Instance.PnlContainer.Controls.Add(test);

				else
				{

					Form1.Instance.PnlContainer.Controls.RemoveByKey("test");
					Form1.Instance.PnlContainer.Controls.Add(test);
				}
				Form1.Instance.PnlContainer.Controls["test"].BringToFront();
				cthd.Clear();
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			//if (listView1.SelectedItems.Count > 0)
			//{
			//	ListViewItem item = listView1.SelectedItems[0];
			//	listView1.Items.Remove(item);
			//	cthd.RemoveAll(x => x.TENTU == item.Text);
			//	int tmp = 0;
			//	foreach (ListViewItem itemRow in listView1.Items)
			//		//MessageBox.Show(itemRow.SubItems[2].ToString());
			//		tmp += int.Parse(itemRow.SubItems[2].Text.ToString());
			//	_tongtien = tmp;
			//	label1.Text = "TỔNG TIỀN= " + _tongtien.ToString();
			//	if(listView1.Items.Count - 1 >= 0 )
			//		listView1.Items[listView1.Items.Count - 1].Selected = true;
			//}
		}


        private void btnXoaHet_Click(object sender, EventArgs e)
        {
			dataGridView1.Rows.Clear();
			_tongtien = 0;
			label1.Text = "TỔNG TIỀN";
			cthd.Clear();

		}

		public void updateTien()
        {
			_tongtien = 0;
			foreach (DataGridViewRow row in dataGridView1.Rows)
				_tongtien += int.Parse(row.Cells[2].Value.ToString());

			label1.Text = "TỔNG TIỀN= " + _tongtien.ToString();

		}


      
		public void ClickTang(int RowIndex)
		{
			string values = dataGridView1[0, RowIndex].Value.ToString();
			int sl = int.Parse(dataGridView1[1, RowIndex].Value.ToString());
			int tien = int.Parse(dataGridView1[2, RowIndex].Value.ToString());
			sl++;
			dataGridView1[1, RowIndex].Value = sl;
			dataGridView1[2, RowIndex].Value = (tien / (sl-1)) * (sl) ;
			updateTien();

		}

		public void ClickGiam(int RowIndex)
		{
			string values = dataGridView1[0, RowIndex].Value.ToString();
			int sl = int.Parse(dataGridView1[1, RowIndex].Value.ToString());
			int tien = int.Parse(dataGridView1[2, RowIndex].Value.ToString());
			sl--;
			if (sl != 0)
			{ 				
				
				dataGridView1[1, RowIndex].Value = sl;
				dataGridView1[2, RowIndex].Value = (tien / (sl +1)) * (sl);
			}
			if(sl == 0)
            {
				dataGridView1.Rows.RemoveAt(RowIndex);
				cthd.RemoveAll(v => v.TENTU.Contains(values));
			}
			updateTien();
			
		}
		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			var grid = (DataGridView)sender;

			if (e.RowIndex < 0)
				return;

			if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
				if (e.ColumnIndex == 3)
					ClickTang(e.RowIndex);
				else
					ClickGiam(e.RowIndex);
		}
    }
}
