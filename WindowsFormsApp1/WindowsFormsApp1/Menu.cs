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

		//List<Bill> listBill = new List<Bill>();
		List<ChiTietHoaDon> cthd = new List<ChiTietHoaDon>();

		private void ButtonClickHandler(object sender, EventArgs e)
		{
			var button = (Button)sender;
			ChiTietHoaDon tmp = new ChiTietHoaDon();
			tmp.IDTU = int.Parse(button.Name);
			tmp.GIATIEN = int.Parse(button.Tag.ToString());
			tmp.TENTU = button.Text;

			if (!(cthd.Exists(x => x.IDTU == tmp.IDTU)))
            {
				tmp.SOLUONG = 1;
				cthd.Add(tmp);
				string[] row = { button.Text, "1", button.Tag + "" };
                var listviewitem = new ListViewItem(row);
                listView1.Items.Add(listviewitem);
                _tongtien += int.Parse(tmp.GIATIEN.ToString());

            }
			else
            {
				int tmpSL = int.Parse(listView1.FindItemWithText(button.Text).SubItems[1].Text.ToString());
                tmpSL++;
                listView1.FindItemWithText(button.Text).SubItems[1].Text = tmpSL.ToString();
                listView1.FindItemWithText(button.Text).SubItems[2].Text = (tmpSL * tmp.GIATIEN).ToString();
				cthd.Where(x => x.IDTU == tmp.IDTU).Select(c => { c.SOLUONG = tmpSL; return c; }).ToList();
                _tongtien += tmp.GIATIEN;
            }

			label1.Text = "TỔNG TIỀN= " + _tongtien.ToString();
			listView1.Items[listView1.Items.Count-1].Selected = true;

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
			if (listView1.Items.Count == 0)
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
				foreach (ChiTietHoaDon v in cthd)
					tmptongtien += v.GIATIEN * v.SOLUONG;
				HoaDon hd = new HoaDon(cthd);
				hd.TONGTIEN = tmptongtien;
				test.Hoadon = hd;
				if (!Form1.Instance.PnlContainer.Controls.ContainsKey("test"))
				{

					Form1.Instance.PnlContainer.Controls.Add(test);
				}
				else
				{

					Form1.Instance.PnlContainer.Controls.RemoveByKey("test");
					Form1.Instance.PnlContainer.Controls.Add(test);
				}
				Form1.Instance.PnlContainer.Controls["test"].BringToFront();
				//label1.Text = "Tổng tiền";
				//_tongtien = 0;
				//cthd.Clear();
				//listView1.Items.Clear();
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				ListViewItem item = listView1.SelectedItems[0];
				listView1.Items.Remove(item);
				cthd.RemoveAll(x => x.TENTU == item.Text);
				int tmp = 0;
				foreach (ListViewItem itemRow in listView1.Items)
					//MessageBox.Show(itemRow.SubItems[2].ToString());
					tmp += int.Parse(itemRow.SubItems[2].Text.ToString());
				_tongtien = tmp;
				label1.Text = "TỔNG TIỀN= " + _tongtien.ToString();
				if(listView1.Items.Count - 1 >= 0 )
					listView1.Items[listView1.Items.Count - 1].Selected = true;
			}
		}


        private void btnXoaHet_Click(object sender, EventArgs e)
        {
			listView1.Items.Clear();
			_tongtien = 0;
			label1.Text = "TỔNG TIỀN";
			cthd.Clear();

		}
    }
}
