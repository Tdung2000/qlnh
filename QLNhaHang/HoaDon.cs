using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaHang
{
    class HoaDon
    {
        public string mahd { get; set; }
        public DateTime ngaylap{ get; set; }
        public string manv{ get; set; }
        public string makh{ get; set; }

        public int tongtien { get; set; }
        public HoaDon()
        {

        }
        public HoaDon(string mahd,DateTime ngaylap,string manv,string makh )
        {
            this.mahd = mahd;
            this.ngaylap = ngaylap;
            this.manv = manv;
            this.makh = makh;
        }

    }
}
