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
           string constr = @"Data Source=DUYHV\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True";
            con = new SqlConnection(constr);
        }
        //lay du lieu nhan vien
        public DataTable danhsachNV()
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select * from nhanvien order by manhanvien";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        //Lay du lieu ra bang
        public DataTable hienthiHD()
        {
            con.Open();
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
            
            string sql = "select mamenu,tenmonan,soluong from chitiethoadon "
                +"inner join monan on monan.mamonan=chitiethoadon.mamonan " +
                "where mahoadon='"+mahd+"'";
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
            string sql = "select * from banan order by mabanan";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        //tim nhan vien
        public DataTable timnhanvien(String manv)
        {

            con.Open();
            DataTable table = new DataTable();
            string sql = "select * from nhanvien where manhanvien='"+manv+"'";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        //Them, sua, xoa nhan vien.
        public void themNV(NhanVien s)
        {
            con.Open();
            string sql = "insert into nhanvien values(@manhanvien,@tennhanvien," +
                "@gioitinh,@tuoi,@diachi,@sodienthoai)";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.Parameters.AddWithValue("manhanvien", s.MaNV);
            cmd.Parameters.AddWithValue("tennhanvien", s.TenNV);
            cmd.Parameters.AddWithValue("gioitinh", s.GioiTinh);
            cmd.Parameters.AddWithValue("tuoi", s.Tuoi);
            cmd.Parameters.AddWithValue("diachi", s.DiaChi);
            cmd.Parameters.AddWithValue("sodienthoai", s.SoDienThoai);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void suaNV(NhanVien s)
        {
            con.Open();
            string sql = "update nhanvien set tennhanvien=@tennhanvien," +
                "gioitinh=@gioitinh,tuoi=@tuoi," +
                "diachi=@diachi,sodienthoai=@sodienthoai where manhanvien='"+s.MaNV+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("tennhanvien", s.TenNV);
            cmd.Parameters.AddWithValue("gioitinh", s.GioiTinh);
            cmd.Parameters.AddWithValue("tuoi", s.Tuoi);
            cmd.Parameters.AddWithValue("diachi", s.DiaChi);
            cmd.Parameters.AddWithValue("sodienthoai", s.SoDienThoai);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void xoaNV(NhanVien s)
        {
            con.Open();
            string sql = "delete from nhanvien where manhanvien=@manhanvien";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("manhanvien", s.MaNV);
            cmd.ExecuteNonQuery();

            con.Close();
        }
        //Them sua xoa ban an
        public void ThemBA(BanAn s)
        {
            con.Open();
            String sql = "insert into banan values(@mabanan,@soghe,@tinhtrang)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("mabanan", s.Mabanan);
            cmd.Parameters.AddWithValue("soghe", s.Soghe);
            cmd.Parameters.AddWithValue("tinhtrang", s.Tinhtrang);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void XoaBA(BanAn s)
        {
            con.Open();
            String sql = "delete from banan where mabanan='" + s.Mabanan + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void SuaBA(BanAn s)
        {
            con.Open();
            string sql = "update banan set soghe=@soghe,tinhtrang=@tinhtrang where mabanan='"+s.Mabanan+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("soghe", s.Soghe);
            cmd.Parameters.AddWithValue("tinhtrang", s.Tinhtrang);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }   
}
