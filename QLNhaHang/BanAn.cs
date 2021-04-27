using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaHang
{
    class BanAn
    {
        public String Mabanan { get; set; }
        public int Soghe { get; set; }
        public String Tinhtrang { get; set; }
        public BanAn() { }
        public BanAn(String mabanan,int soghe,String tinhtrang)
        {
            this.Mabanan = mabanan;
            this.Soghe = soghe;
            this.Tinhtrang = tinhtrang;
        }
    }
}
