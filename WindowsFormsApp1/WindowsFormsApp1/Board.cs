using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Board : UserControl
    {
        string _doanhso;
        public string Doanhso { get => _doanhso; set => _doanhso = value; }

        public void changeText(string text,string text2)
        {
            label1.Text = text + "";
            TongDoanhThu.Text = "Hôm nay bán dược: " + text2 + "";
        }
        public Board()
        {
            InitializeComponent();
        }

        private void Board_Load(object sender, EventArgs e)
        {
            NgayHienTai.Text = "Hôm nay là: " + DateTime.Now.ToString("dd - MM - yyyy"); 
            
        }
    }
}
