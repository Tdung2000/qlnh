using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaHang
{
    public partial class Form1 : Form
    {
        Utilities data = new Utilities();
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           //Không cho phép thay đổi dữ liệu 3 cột đầu danh sách món ăn đã chọn trong mục gọi món
            dgvdsMondachon.Columns[0].ReadOnly = true;
            dgvdsMondachon.Columns[1].ReadOnly = true;
            dgvdsMondachon.Columns[2].ReadOnly = true;

            goimon();
            dgvdsmonan.DataSource = data.danhsachmonantheoloai(
                    cbxLoaimonan.SelectedValue.ToString());
        }
        //display
        public void DisplayHoadon()
        {
            dgvDSHoaDon.DataSource = data.hienthiHD();
        }
        public void DisplayctHoadon(string mahd)
        {
            dgvChiTietHD.DataSource = data.hienthichitietHD(mahd);
        }
         //clear
        public void clearHD()
        {
            txtMaHD.Clear();
            cbxUpdateNV.SelectedIndex = 0;
            dtpNgaylap.Value = DateTime.Now;
            cbxUpdateKH.SelectedIndex = 0;
            cbxTenmenu.SelectedIndex=0;
            cbxTenmonan.SelectedIndex = 0;
            txtSoLuong.Clear();

        }
         //xử lý
        //gọi món

        private void goimon()
        {
            cbxLoaimonan.DataSource = data.danhsachloai();
            cbxLoaimonan.DisplayMember = "mota";
            cbxLoaimonan.ValueMember = "mota";

            cbxLoaimonan.Enabled = true;
            cbxGoimonMenu.Enabled = false;

            cbxGoimonMenu.DataSource = data.danhsachmenu();
            cbxGoimonMenu.DisplayMember = "tenmenu";
            cbxGoimonMenu.ValueMember = "mamenu";

            cbxGoimonBan.DataSource = data.danhsachban();
            cbxGoimonBan.DisplayMember = "mabanan";
            cbxGoimonBan.ValueMember = "mabanan";


        }
        int n = 0;
        int m = 0;
        private void getHD(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            try
            {
                txtMaHD.Text = dgvDSHoaDon.Rows[index].Cells[0].Value.ToString();
                txtNgayLap.Text = dgvDSHoaDon.Rows[index].Cells[1].Value.ToString();
                txtNguoiLap.Text = dgvDSHoaDon.Rows[index].Cells[2].Value.ToString();
                txtKhach.Text = dgvDSHoaDon.Rows[index].Cells[3].Value.ToString();
                DisplayctHoadon(txtMaHD.Text);
            }
            catch(Exception ex)
            {

            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        //lập hóa đơn
        private void laphoadon()
        {
            cbxBanan.DataSource = data.danhsachban();
            cbxBanan.DisplayMember = "mabanan";
            cbxBanan.ValueMember = "mabanan";
            cbxNhanVien.DataSource = data.danhsachnhanvien();
            cbxNhanVien.DisplayMember = "tennhanvien";
            cbxNhanVien.ValueMember = "manhanvien";
        }
        private void capnhatHD()
        {
            cbxUpdateNV.DataSource = data.danhsachnhanvien();
            cbxUpdateNV.DisplayMember = "tennhanvien";
            cbxUpdateNV.ValueMember = "manhanvien";

            cbxUpdateKH.DataSource = data.danhsachKH();
            cbxUpdateKH.DisplayMember = "tenkhachhang";
            cbxUpdateKH.ValueMember = "makhachhang";

            cbxTenmenu.DataSource = data.danhsachmenu();
            cbxTenmenu.DisplayMember = "tenmenu";
            cbxTenmenu.ValueMember = "mamenu";

            string menu = cbxTenmenu.SelectedValue.ToString();
            cbxTenmonan.DataSource = data.danhsachmonantheomenu(menu);
            cbxTenmonan.DisplayMember = "tenmonan";
            cbxTenmonan.ValueMember = "tenmonan";
        }

        private void tabcontrol_click(object sender, EventArgs e)
        {
            check_tab();
        }
        private void check_tab()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                   
                    break;
                case 2:
                    laphoadon();
                    break;
                case 3:
                    capnhatHD();
                    DisplayHoadon();
                    break;
                case 4:
                    HienThiNhanVien();
                    break;
                case 5:
                    HienThiBanAn();

                    break;
            }
        }
        private void locloaimon()
        {
            cbxLoaimonan.DataSource = data.danhsachloai();
            cbxLoaimonan.DisplayMember = "mota";
            cbxLoaimonan.ValueMember = "mota";
            cbxLoaimonan.SelectedIndex = 0;

            dgvdsmonan.DataSource = data.danhsachmonantheoloai(
                    cbxLoaimonan.SelectedValue.ToString());
        }
         //Cell_Click

        private void getHD(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            try
            {
                txtMaHD.Text = dgvDSHoaDon.Rows[index].Cells[0].Value.ToString();
                dtpNgaylap.Text = dgvDSHoaDon.Rows[index].Cells[1].Value.ToString();
                cbxUpdateNV.Text = dgvDSHoaDon.Rows[index].Cells[2].Value.ToString();
                cbxUpdateKH.Text = dgvDSHoaDon.Rows[index].Cells[3].Value.ToString();

                DisplayctHoadon(txtMaHD.Text);
                if (dgvChiTietHD.Rows[0].Cells[0].Value.ToString()!="")
                {
                    cbxTenmenu.Text = dgvChiTietHD.Rows[0].Cells[0].Value.ToString();
                    cbxTenmonan.Text = dgvChiTietHD.Rows[0].Cells[1].Value.ToString();
                    txtSoLuong.Text = dgvChiTietHD.Rows[0].Cells[2].Value.ToString();
                }
                if (cbxTenmonan.Items.Count <= 0)
                {
                    cbxTenmonan.Text = "";
                    cbxTenmonan.Enabled = false;
                }
                else
                    cbxTenmonan.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        private void dgvChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            try
            {
                cbxTenmenu.Text = dgvChiTietHD.Rows[index].Cells[0].Value.ToString();
                cbxTenmonan.Text = dgvChiTietHD.Rows[index].Cells[1].Value.ToString();
                txtSoLuong.Text = dgvChiTietHD.Rows[index].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void HienThiNhanVien()
        {
            txtmanvs.Text = "";
            txtmanvs.Focus();
            txttennvs.Text = "";
            cbbGioitinhs.Text = "";
            txtsodienthoais.Text = "";
            txtdiachis.Text = "";
            txttuois.Text = "";
            txttramasv.Text = "";

            dataGridView2.DataSource = data.danhsachNV();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDSHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            try
            {
                txtmanvs.Text = dataGridView2.Rows[index].Cells[0].Value.ToString();
                txttennvs.Text = dataGridView2.Rows[index].Cells[1].Value.ToString();
                cbbGioitinhs.Text = dataGridView2.Rows[index].Cells[2].Value.ToString();
                txttuois.Text = dataGridView2.Rows[index].Cells[3].Value.ToString();
                txtdiachis.Text = dataGridView2.Rows[index].Cells[4].Value.ToString();
                txtsodienthoais.Text = dataGridView2.Rows[index].Cells[5].Value.ToString();
            }
            catch(Exception ex)
            {

            }
        }

        private void btnTims_Click(object sender, EventArgs e)
        {
          
                int n = dataGridView2.RowCount;
                Boolean a = false;
                for (int i = 0; i < n - 1; i++)
                {
                    String b = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    if (txttramasv.Text.Equals(b))
                    {
                        a = true;
                    }
                }
                if (a == false)
                {
                    MessageBox.Show("Mã nhân viên không hợp lệ.", "ERROR");
                    return;
                }
                dataGridView2.DataSource = data.timnhanvien(txttramasv.Text);
                txtmanvs.Text = dataGridView2.Rows[0].Cells[0].Value.ToString();
                txttennvs.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                cbbGioitinhs.Text = dataGridView2.Rows[0].Cells[2].Value.ToString();
                txttuois.Text = dataGridView2.Rows[0].Cells[3].Value.ToString();
                txtdiachis.Text = dataGridView2.Rows[0].Cells[4].Value.ToString();
                txtsodienthoais.Text = dataGridView2.Rows[0].Cells[5].Value.ToString();
            }          

        private void btnDSSVs_Click(object sender, EventArgs e)
        {
            HienThiNhanVien();
        }

        private void btnThems_Click(object sender, EventArgs e)
        {
            
            try
            {
                txttennvs.Focus();
                m = 1;
                int count = 0;
                count = dataGridView2.Rows.Count;
                string chuoi = Convert.ToString(dataGridView2.Rows[count - 2].Cells[0].Value);
                int chuoi2 = 0;
                chuoi2 = Convert.ToInt32(chuoi.Remove(0, 3));
                if(chuoi2 + 1 < 10)
                {
                    txtmanvs.Text = "nvn" + (chuoi2 + 1).ToString();
                }
                else
                {
                    txtmanvs.Text="nvn"+ (chuoi2 + 1).ToString();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                return;
            }
            /*int n = dataGridView2.RowCount;
            Boolean a = false;
            for(int i = 0; i < n-1; i++)
            {
                String b = dataGridView2.Rows[i].Cells[0].Value.ToString();
                if (nv.MaNV.Equals(b))
                {
                    a = true;
                }
            }
            if (a == true)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ.", "ERROR");
                return;
            }
            data.themNV(nv);
            HienThiNhanVien();
            return;*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSuas_Click(object sender, EventArgs e)
        {
            m = 2;
            txttennvs.Focus();
            /*int n = dataGridView2.RowCount;
            Boolean a = false;
            for (int i = 0; i < n - 1; i++)
            {
                String b = dataGridView2.Rows[i].Cells[0].Value.ToString();
                if (nv.MaNV.Equals(b))
                {
                    a = true;
                }
            }
            if (a == false)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ.", "ERROR");
                return;
            }
            data.suaNV(nv);
            HienThiNhanVien();*/
        }

        private void btnXoas_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nv = new NhanVien();
                nv.MaNV = txtmanvs.Text;
                if (txtmanvs.Text == "")
                    return;
                DialogResult dlr = MessageBox.Show("Bạn có muốn xóa nhân viên có mã:" + nv.MaNV + ".", "Thông báo", MessageBoxButtons.OKCancel);
                if (dlr == DialogResult.OK)
                {
                    data.xoaNV(nv);
                    MessageBox.Show("Xóa thành công.", "Thông báo");
                    HienThiNhanVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                return;
            }
        }
        //danh sach ban an
        public void HienThiBanAn()
        {
            dataBanan.DataSource = data.danhsachban();
        }

        private void dataBanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtMabanans.Text = dataBanan.Rows[index].Cells[0].Value.ToString();
            txtsoghes.Text = dataBanan.Rows[index].Cells[1].Value.ToString();
            cbbtrangthais.Text = dataBanan.Rows[index].Cells[2].Value.ToString();
        }

        private void btnthembans_Click(object sender, EventArgs e)
        {
            try
            {
                n = 1;
                txtsoghes.Focus();
                int count = dataBanan.Rows.Count;
            String chuoi = dataBanan.Rows[count - 2].Cells[0].Value.ToString();
            int chuoi2 = 0;
            chuoi2 = Convert.ToInt32(chuoi.Remove(0, 3));
            if (chuoi2 + 1 < 10)
                txtMabanans.Text = "Ban" + (chuoi2 + 1).ToString();
            else
            {
                if (chuoi2 + 1 <= 20)
                    txtMabanans.Text = "Ban" + (chuoi2 + 1).ToString();
                else
                {
                    MessageBox.Show("Không còn bàn trống.", "Thông báo");
                    return;
                }
            }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
                return;
            }
        }

        private void btnxoabans_Click(object sender, EventArgs e)
        {
            try
            {
                BanAn ba = new BanAn();
                ba.Mabanan = txtMabanans.Text;
                DialogResult dlr= MessageBox.Show("Bạn có muốn xóa bàn có mã:"+ba.Mabanan+ ".", "Thông báo",MessageBoxButtons.OKCancel);
                if (dlr == DialogResult.OK)
                {
                    data.XoaBA(ba);
                    MessageBox.Show("Xóa thành công.", "Thông báo");
                    HienThiBanAn();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
                return;
            }
        }

        private void btnsuabans_Click(object sender, EventArgs e)
        {
            try
            {
                n = 2;
                txtsoghes.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
                return;
            }
        }
        private void dgvdsmonan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool khuyenmai = true;
                int index = e.RowIndex;
                string tenmon = dgvdsmonan.Rows[index].Cells[0].Value.ToString();
                string tenmenu = dgvdsmonan.Rows[index].Cells[1].Value.ToString();
                string dongia = dgvdsmonan.Rows[index].Cells[2].Value.ToString();
                int soluong = 1;
                int sum = 0;

                int n = dgvdsMondachon.Rows.Count;

                if (n > 1)
                {
                    if (!dgvdsMondachon.Rows[n - 2].Cells[1].Value.ToString().Equals(dgvdsMondachon.Rows[0].Cells[1].Value.ToString()))
                        khuyenmai = false;
                    for (int i = 0; i < n - 1; i++)
                    {
                        if (dgvdsMondachon.Rows[i].Cells[0].Value.ToString().Equals(tenmon))
                        {
                            dgvdsMondachon.Rows[i].Cells[3].Value = int.Parse(dgvdsMondachon.Rows[i].Cells[3].Value.ToString()) + 1 + "";
                            for (int j = 0; j < dgvdsMondachon.Rows.Count - 1; j++)
                            {

                                sum += (int.Parse(dgvdsMondachon.Rows[j].Cells[3].Value.ToString()) * int.Parse(dgvdsMondachon.Rows[j].Cells[2].Value.ToString()));
                            }
                            txtGoimonMoney.Text = sum + "";

                            return;
                        }
                    }
                    dgvdsMondachon.Rows.Add(tenmon, tenmenu, dongia, soluong);
                }
                else
                {
                    dgvdsMondachon.Rows.Add(tenmon, tenmenu, dongia, soluong);
                    for (int j = 0; j < dgvdsMondachon.Rows.Count - 1; j++)
                    {

                        sum += (int.Parse(dgvdsMondachon.Rows[j].Cells[3].Value.ToString()) * int.Parse(dgvdsMondachon.Rows[j].Cells[2].Value.ToString()));
                    }
                    txtGoimonMoney.Text = sum + "";
                }

                if (khuyenmai)
                {
                    txtGoimonKM.Text = "10";
                }
                else
                    txtGoimonKM.Text = "0";
            }
            catch (Exception)
            {

            }

        }

        //generateID
        public int generateID(DataGridView dgv)
        {
            int dgvSize = dgv.Rows.Count;
            int id = int.Parse(dgv.Rows[dgvSize - 1].Cells[0].Value.ToString().Substring(3));

            return id;
        }


        //button_Click
        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            data.deleteHD(txtMaHD.Text);
            DisplayHoadon();
            clearHD();
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            data.addHD(generateID(dgvDSHoaDon),hd);
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {

            HoaDon hd = new HoaDon();
            hd.mahd = txtMaHD.Text;
            hd.manv = cbxUpdateNV.SelectedValue.ToString();
            hd.makh = cbxUpdateKH.SelectedValue.ToString();
            hd.ngaylap = dtpNgaylap.Value;

            string mamenu=cbxTenmenu.SelectedValue.ToString();
            string mamonan=cbxTenmonan.SelectedValue.ToString();
            int soluong=int.Parse(txtSoLuong.Text);


            data.updateHD(hd,mamonan,soluong);
            DisplayHoadon();
            DisplayctHoadon(dgvDSHoaDon.Rows[0].Cells[0].Value.ToString());
            clearHD();
        }
        private void btnGoimonAdd_Click(object sender, EventArgs e)
        {
            List<ThucDon> li = new List<ThucDon>();

            int n = dgvdsmonan.Rows.Count;
            for (int i = 0; i < n-1; i++)
            {
                ThucDon td = new ThucDon();
                td.tenmon = dgvdsmonan.Rows[i].Cells[0].Value.ToString();
                td.tenmenu = dgvdsmonan.Rows[i].Cells[1].Value.ToString();
                td.dongia = int.Parse(dgvdsmonan.Rows[i].Cells[2].Value.ToString());
                td.soluong = 1;
                li.Add(td);
            }
            foreach (var item in li)
            {
                n = dgvdsMondachon.Rows.Count;
                if (n>1)
                {
                    bool Exist = false;
                    for (int i = 0; i < n-1; i++)
                    {
                        if (item.tenmon.Equals(dgvdsMondachon.Rows[i].Cells[0].Value.ToString()))
                        {
                            dgvdsMondachon.Rows[i].Cells[3].Value = int.Parse(dgvdsMondachon.Rows[i].Cells[3].Value.ToString()) + 1 + "";
                            Exist = true;
                            break;
                        }

                    }
                    if (!Exist)
                    {
                        dgvdsMondachon.Rows.Add(item.tenmon, item.tenmenu, item.dongia, item.soluong);
                    }
                }else
                    dgvdsMondachon.Rows.Add(item.tenmon,item.tenmenu,item.dongia,item.soluong);
            }

        }

        //radio changed
        private void goimon(object sender, EventArgs e)
        {
            if (radMonan.Checked)
            {
                cbxLoaimonan.Enabled = true;
                cbxGoimonMenu.Enabled = false;
                dgvdsmonan.Enabled = true;
                dgvdsmonan.DataSource = data.danhsachmonantheoloai(
                cbxLoaimonan.SelectedValue.ToString());
            }
            else if (radMenu.Checked)
            {
                dgvdsmonan.Enabled = false;
                cbxLoaimonan.Enabled = false;
                cbxGoimonMenu.Enabled = true;
                dgvdsmonan.DataSource = data.danhsachmonantheomenu(
               cbxGoimonMenu.SelectedValue.ToString());
            }
        }

        //Text_changed
        private void cbxLoaimonan_TextChanged(object sender, EventArgs e)
        {
            dgvdsmonan.DataSource = data.danhsachmonantheoloai(
                cbxLoaimonan.SelectedValue.ToString());
        }
        private void cbxGoimonMenu_TextChanged(object sender, EventArgs e)
        {
            dgvdsmonan.DataSource = data.danhsachmonantheomenu(
                cbxGoimonMenu.SelectedValue.ToString());
        }

        private void cbxTenmenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string menu = cbxTenmenu.SelectedValue.ToString();
            cbxTenmonan.DataSource = data.danhsachmonantheomenu(menu);
            cbxTenmonan.DisplayMember = "tenmonan";
            cbxTenmonan.ValueMember = "tenmonan";
            if (cbxTenmonan.Items.Count<=0)
            {
                cbxTenmonan.Text = "";
                cbxTenmonan.Enabled = false;
            }
            else
                cbxTenmonan.Enabled = true;
        private void btnLuus_Click(object sender, EventArgs e)
        {
            if (n == 1)
            {
                try
                {
                    BanAn ba = new BanAn();
                    ba.Mabanan = txtMabanans.Text;
                    ba.Soghe = int.Parse(txtsoghes.Text);
                    ba.Tinhtrang = cbbtrangthais.Text;
                    data.ThemBA(ba);
                    MessageBox.Show("Thêm thành công.", "Thông báo");
                    HienThiBanAn();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERROR");
                    return;
                }
            }
            if (n == 2)
            {
                try
                {
                    BanAn ba = new BanAn();
                    ba.Mabanan = txtMabanans.Text;
                    ba.Soghe = int.Parse(txtsoghes.Text);
                    ba.Tinhtrang = cbbtrangthais.Text;
                    data.SuaBA(ba);
                    MessageBox.Show("Sửa thành công.", "Thông báo");
                    HienThiBanAn();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERROR");
                    return;
                }
            }
        }

        private void btnluuss_Click(object sender, EventArgs e)
        {
            if (m == 1)
            {
                try
                {
                    NhanVien nv = new NhanVien();
                    nv.MaNV = txtmanvs.Text;
                    nv.TenNV = txttennvs.Text;
                    nv.GioiTinh = cbbGioitinhs.Text;
                    nv.Tuoi = int.Parse(txttuois.Text);
                    nv.DiaChi = txtdiachis.Text;
                    nv.SoDienThoai = txtsodienthoais.Text;
                    data.themNV(nv);
                    MessageBox.Show("Thêm thành công.", "Thông báo");
                    HienThiNhanVien();
                    return;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERROR");
                    return;
                }
            }
            if (m == 2)
            {
                try
                {
                    NhanVien nv = new NhanVien();
                    nv.MaNV = txtmanvs.Text;
                    nv.TenNV = txttennvs.Text;
                    nv.GioiTinh = cbbGioitinhs.Text;
                    nv.Tuoi = int.Parse(txttuois.Text);
                    nv.DiaChi = txtdiachis.Text;
                    nv.SoDienThoai = txtsodienthoais.Text;
                    data.suaNV(nv);
                    MessageBox.Show("Sửa thành công.", "Thông báo");
                    HienThiNhanVien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                    return;
                }
            }
        }
    }
}
