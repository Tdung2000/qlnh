using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaHang
{
    class ThucDon
    {
        public String tenmon{ get; set; }
        public String tenmenu{ get; set; }
        public int dongia{ get; set; }
        public int soluong{ get; set; }

        public ThucDon()
        {

        }
        public ThucDon(string tenmon,string tenmenu,string dongia,int soluong)
        {
            this.tenmon = tenmon;
            this.tenmenu = tenmenu;
            this.dongia = int.Parse(dongia);
            this.soluong = soluong;
        }
    }
}
