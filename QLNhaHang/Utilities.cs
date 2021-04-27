using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace QLNhaHang
{
    class Utilities
    {
        SqlConnection con;
        public Utilities()
        {
           string constr = @"Data Source=DESKTOP-DHL2NL5\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=true";
            con = new SqlConnection(constr);
        }
        //Lay du lieu ra bang
        public DataTable hienthiHD()
        {
            DataTable table = new DataTable();
            string sql = "select hoadon.mahoadon,ngaylap,tennhanvien,tenkhachhang,sum(soluong*Gia) as 'tien' " +
                "from hoadon,KhachHang,NhanVien,ChiTietHoaDon,MonAn " +
                "where HoaDon.MaHoaDon=ChiTietHoaDon.MaHoaDon " +
                "and ChiTietHoaDon.MaMonAn=MonAn.MaMonAn " +
                "and hoadon.makhachhang=khachhang.makhachhang " +
                "and hoadon.manhanvien=nhanvien.manhanvien " +
                "group by HoaDon.MaHoaDon,ngaylap,tennhanvien,tenkhachhang ";
            SqlDataAdapter adap = new SqlDataAdapter(sql,con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        //lay du lieu chi tiet hoa don
        public DataTable hienthichitietHD(string mahd)
        {
            con.Open();
            DataTable table = new DataTable();
            
            string sql = "select tenmenu,tenmonan,soluong from monan,chitiethoadon,menu " +
                "where monan.mamonan=chitiethoadon.mamonan " +
                "and menu.mamenu=monan.mamenu " +
                "and mahoadon='" + mahd + "'";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("mahd", mahd);
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        //lay du lieu chi tiet mon an

        //lay du lieu ban an
        public DataTable danhsachban()
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select * from banan";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }

        //NHan vien
        //Lay du lieu nhan vien
        public DataTable danhsachnhanvien()
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select * from nhanvien";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }

        //NHan vien
        //Lay danh sach khach hang
        public DataTable danhsachKH()
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select * from khachhang";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        //menu
        //lay du lieu
        public DataTable danhsachmenu()
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select * from Menu";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }

        //mon an
        //lay du lieu mon an

        public DataTable danhsachmonan()
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select * from MonAn";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        //danh sach loai mon an
        public DataTable danhsachloai()
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select distinct mota from MonAn";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        public DataTable danhsachmonantheoloai(string loaimonan)
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select tenmonan,menu.tenmenu,gia,monan.mota from monan,menu where monan.mamenu=menu.mamenu and monan.mota=N'" + loaimonan+"'";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }

        public DataTable danhsachmonantheomenu(string mamenu)
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select tenmonan,menu.tenmenu,gia,monan.mota from monan,menu where monan.mamenu=menu.mamenu and monan.mamenu=N'" + mamenu + "'";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        //HD
        //delete
        public void deleteHD(string strMatch)
        {
            con.Open();
            string sql = "delete from chitiethoadon where mahoadon=@strMatch;" +
                "delete from hoadon where mahoadon=@strMatch";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("strMatch", strMatch);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //Add
        public void addHD(int lastindex, HoaDon hd)
        {
            string mahd = "hdn"+lastindex.ToString();
            con.Open();
            string sql = "insert into hoadon values (@mahd,@ngaylap,@manhanvien, @makhachhang);";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("mahd",mahd);
            cmd.Parameters.AddWithValue("ngaylap",hd.ngaylap);
            cmd.Parameters.AddWithValue("manhanvien",hd.manv);
            cmd.Parameters.AddWithValue("makhachhang",hd.makh);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //update
        public void updateHD(HoaDon hd, string mamonan, int soluong)
        {
            con.Open();
            string sql1 = "update chitiethoadon set mamonan=@mamonan, soluong=@soluong where mahoadon= @mahd;";
            string sql2 = "update hoadon set ngaylap=@ngaylap,manhanvien=@manhanvien,makhachhang=@makhachhang where mahoadon= @mahd;";
            
            

            SqlCommand cmd = new SqlCommand(sql1, con);
            cmd.Parameters.AddWithValue("mahd", hd.mahd);
            
            cmd.Parameters.AddWithValue("mamonan", mamonan);
            cmd.Parameters.AddWithValue("soluong", soluong);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand(sql2, con);
            cmd.Parameters.AddWithValue("mahd", hd.mahd);
            cmd.Parameters.AddWithValue("ngaylap", hd.ngaylap);
            cmd.Parameters.AddWithValue("manhanvien", hd.manv);
            cmd.Parameters.AddWithValue("makhachhang", hd.makh);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
