using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ThucUong
    {
        int _IDTU;
        string _TEN;   
        int _GIATIEN;

        public int IDTU { get => _IDTU; set => _IDTU = value; }
        public string TEN { get => _TEN; set => _TEN = value; }
        public int GIATIEN { get => _GIATIEN; set => _GIATIEN = value; }

        public ThucUong()
        {

        }

        public ThucUong(int iDTU, string tEN, int gIATIEN)
        {
            IDTU = iDTU;
            TEN = tEN;
            GIATIEN = gIATIEN;
        }
    }
    class Bill
    {
        List<ThucUong> _Fbill;
        int _IDTU;
        int _SOLUONG;
        int _TIEN;
        int _TONGTIEN;
        int _TIENDUA;
        int _TIENTRA;
        DateTime _THOIGIAN;

        public Bill()
        {
            Fbill = new List<ThucUong>();
        }
        public List<ThucUong> Fbill { get => _Fbill; set => _Fbill = value; }
        public int IDTU { get => _IDTU; set => _IDTU = value; }
        public int SOLUONG { get => _SOLUONG; set => _SOLUONG = value; }
        public int TIEN { get => _TIEN; set => _TIEN = value; }
        public int TONGTIEN { get => _TONGTIEN; set => _TONGTIEN = value; }
        public int TIENDUA { get => _TIENDUA; set => _TIENDUA = value; }
        public int TIENTRA { get => _TIENTRA; set => _TIENTRA = value; }
        public DateTime THOIGIAN { get => _THOIGIAN; set => _THOIGIAN = value; }

        


    }
}
