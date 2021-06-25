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

			//ThucUong tu = new ThucUong();
			//tu.IDTU = int.Parse(button.Name.ToString());
			//tu.GIATIEN = int.Parse(button.Tag.ToString());
			//tu.TEN = button.Text;

			//Bill cBill = new Bill();

			//if (!(listBill.Exists(x => x.IDTU == tu.IDTU)))
			//         {

			//	cBill.IDTU = tu.IDTU;
			//	cBill.Fbill.Add(tu);
			//	cBill.SOLUONG = 1;
			//	cBill.TIEN = tu.GIATIEN;

			//	string[] row = { tu.TEN,"1",tu.GIATIEN+"" };
			//	var listViewItem = new ListViewItem(row);
			//	listView1.Items.Add(listViewItem);
			//	_tongtien += int.Parse(cBill.TIEN.ToString());
			//	listBill.Add(cBill);

			//}
			//         else
			//{
			//	int tmpSL =int.Parse(listView1.FindItemWithText(tu.TEN).SubItems[1].Text.ToString());
			//	tmpSL++;
			//	listView1.FindItemWithText(tu.TEN).SubItems[1].Text = tmpSL.ToString();
			//	listView1.FindItemWithText(tu.TEN).SubItems[2].Text = (tmpSL * tu.GIATIEN) +"";
			//	listBill.Where(x => x.IDTU == tu.IDTU).Select(c => { c.SOLUONG = tmpSL; return c; }).ToList();
			//	//listBill.Where(x => x.IDTU == tu.IDTU).Select(c => { c.TIEN += tu.GIATIEN; return c; }).ToList();
			//	_tongtien += tu.GIATIEN;
			//}

			//Button button = (Button)sender;
			//string[] array = new string[3]
			//{
			//button.Text,
			//"1",
			//button.Tag?.ToString() ?? ""
			//};
			//ListViewItem listViewItem = new ListViewItem(array);
			//listViewItem.Name = button.Text;
			//if (!listView1.Items.ContainsKey(button.Text))
			//{
			//	listView1.Items.Add(listViewItem);
			//	_tongtien += int.Parse(array[2]);
			//}
			//else
			//{
			//	int num = int.Parse(listView1.Items[button.Text].SubItems[1].Text);
			//	num++;
			//	listView1.Items[button.Text].SubItems[1].Text = (num.ToString() ?? "");
			//	int num2 = int.Parse(array[2]);
			//	int num3 = num * num2;
			//	listView1.Items[button.Text].SubItems[2].Text = (num3.ToString() ?? "");
			//	_tongtien += num2;
			//}
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
				label1.Text = "Tổng tiền";
				_tongtien = 0;
				cthd.Clear();
				listView1.Items.Clear();
			}
		}

	}
}
