using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ChiTietHoaDon
    {
        int _IDHD;
        int _IDTU;
        int _SOLUONG;
        int _GIATIEN;

        public int IDHD { get => _IDHD; set => _IDHD = value; }
        public int IDTU { get => _IDTU; set => _IDTU = value; }
        public int SOLUONG { get => _SOLUONG; set => _SOLUONG = value; }
        public int GIATIEN { get => _GIATIEN; set => _GIATIEN = value; }
        public ChiTietHoaDon()
        {
        }
    }

    class HoaDon
    {
        int _IDHD;
        int _TONGTIEN;
        int _TIENDUA;
        int _TIENTRA;
        DateTime _THOIGIAN;
        List<ChiTietHoaDon> _CTHD;
        public int IDHD { get => _IDHD; set => _IDHD = value; }
        public int TONGTIEN { get => _TONGTIEN; set => _TONGTIEN = value; }
        public int TIENDUA { get => _TIENDUA; set => _TIENDUA = value; }
        public int TIENTRA { get => _TIENTRA; set => _TIENTRA = value; }
        public DateTime THOIGIAN { get => _THOIGIAN; set => _THOIGIAN = value; }
        internal List<ChiTietHoaDon> CTHD { get => _CTHD; set => _CTHD = value; }

        public HoaDon()
        {
            CTHD = new List<ChiTietHoaDon>();
        }
        public HoaDon(List<ChiTietHoaDon> cthd)
        {
            CTHD = new List<ChiTietHoaDon>(cthd);
        }
    }
}
