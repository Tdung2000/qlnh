use master
go
if DB_ID('QLNhaHang') is not null
	drop database QLNhaHang

go
create database QLNhaHang
go
use QLNhaHang
go
------------------------------------------
-------------BANG BAN AN------------------
create table BanAn(
	MaBanAn nvarchar(10) not null primary key,
	SoGhe int not null,
	TinhTrang nvarchar(20) not null
)
--------------NHAP BAN AN---------------------------
insert into BanAn values
('ban1',4,'trong'),
('ban2',4,'trong'),
('ban3',4,'trong'),
('ban4',4,'trong'),
('ban5',4,'trong'),
('ban6',4,'trong'),
('ban7',4,'trong'),
('ban8',4,'trong')

-------------BANG MENU------------------------
create table Menu(
	MaMenu nvarchar(10) not null primary key,
	TenMenu nvarchar(50) not null,
	MoTa text,
)

insert into Menu values
('mnu1',N'Món khai vị',''),
('mnu2',N'Tiệc cưới',''),
('mnu3',N'Tiệc sinh nhật',''),
('mnu4',N'Tiệc mừng thọ','')


-------------BANG MON AN--------------
create table MonAn(
	MaMonAn nvarchar(10) not null primary key,
	TenMonAn nvarchar(50) not null,
	Gia int not null,
	MoTa nvarchar(200),
	MaMenu nvarchar(10) not null,
	constraint fk_monan_menu foreign key (MaMenu)
	references Menu(MaMenu)

)
insert into MonAn values
('mon1',N'Cá kho',20000,N'cá','mnu1'),
('mon2',N'Chuối nấu',10000,N'nấu','mnu1'),
('mon3',N'Khoai tây nấu',22000,N'nấu','mnu2'),
('mon4',N'Canh ngó khoai',12000,N'canh','mnu2'),
('mon5',N'Canh mùng',25000,N'canh','mnu1'),
('mon6',N'Cá rán',22000,N'cá','mnu2')
-------------BANG KHACH HANG----------------------
create table KhachHang(
	MaKhachHang nvarchar(10) not null primary key,
	TenKhachHang nvarchar(60) not null,
	DiaChi nvarchar(100),
	SoDienThoai nchar(12) not null,
	MaBanAn nvarchar(10) not null,
	constraint fk_khachhang_banan foreign key (MaBanAn)
	references BanAn(MaBanAn)
)

insert into KhachHang values
('khg1',N'Nguyễn Văn Tuấn',N'Hà Nội','091234','ban1'),
('khg2',N'Nguyễn Văn Nam',N'Hà Nam','0382','ban2'),
('khg3',N'Nguyễn Thị Vân',N'Hà Tĩnh','0123','ban3'),
('khg4',N'Trần Văn Tuấn',N'Sài Gòn','0987','ban5'),
('khg5',N'Lại Văn Tuấn',N'Hai Dương','01123','ban1'),
('khg6',N'Hà Văn Tuấn',N'Hà Nội','0914234','ban5')
---------------BANG NHAN VIEN--------------------------
create table NhanVien(
	MaNhanVien nvarchar(10) not null primary key,
	TenNhanVien nvarchar(60) not null,
	GioiTinh nvarchar(10),
	Tuoi int not null,
	DiaChi nvarchar(100),
	SoDienThoai nchar(12) not null
)

insert into NhanVien values
('nvn1',N'Trần văn Nguyễn',N'nam',20,N'Hà Nội','0912363523'),
('nvn2',N'Trần Thị Ly',N'nữ',20,N'Hà Nội','09123523'),
('nvn3',N'Lại văn Nguy',N'nam',20,N'Hà Nội','0912523')
----------------BANG HOA DON---------------------------
create table HoaDon(
	MaHoaDon nvarchar(10) not null primary key,
	NgayLap date not null,
	MaNhanVien nvarchar(10) not null,
	MaKhachHang nvarchar(10) not null,
	constraint fk_hoadon_khachhang foreign key (MaKhachHang)
	references KhachHang(MaKhachHang),
	constraint fk_hoadon_nhanvien foreign key (MaNhanVien)
	references NhanVien(MaNhanVien)
)

insert into HoaDon values
('hdn1','12/12/2021','nvn1','khg2'),
('hdn2','11/12/2021','nvn2','khg3'),
('hdn3','9/12/2021','nvn1','khg2'),
('hdn4','10/12/2021','nvn3','khg5'),
('hdn5','7/12/2021','nvn2','khg1')
-------------BANG CHI TIET HOA DON------------------------

create table ChiTietHoaDon(
	MaHoaDon nvarchar(10) not null,
	MaMonAn nvarchar(10),
	SoLuong int,
	constraint pk_chitiethoadon primary key (MaHoaDon, MaMonAn),
	constraint fk_chitiethoadon_hoadon foreign key (MaHoaDon)
	references HoaDon(MaHoaDon),
	constraint fk_chitiethoadon_monan foreign key (MaMonAn)
	references MonAn(MaMonAn)
)

insert into ChiTietHoaDon values
('hdn1','mon1',3),
('hdn1','mon2',3),
('hdn1','mon3',3),
('hdn2','mon1',3),
('hdn3','mon2',3),
('hdn4','mon2',3),
('hdn4','mon1',3),
('hdn5','mon4',3)
go
select * from HoaDon

select MonAn.mamenu,tenmonan,soluong from chitiethoadon 
inner join monan on monan.mamonan=chitiethoadon.mamonan
where mahoadon='hd1'

select hoadon.mahoadon,ngaylap,tennhanvien,tenkhachhang,sum(soluong*Gia) as 'tien'
from hoadon,KhachHang,NhanVien,ChiTietHoaDon,MonAn
where HoaDon.MaHoaDon=ChiTietHoaDon.MaHoaDon
	and ChiTietHoaDon.MaMonAn=MonAn.MaMonAn
	and hoadon.makhachhang=khachhang.makhachhang 
	and hoadon.manhanvien=nhanvien.manhanvien
group by HoaDon.MaHoaDon,ngaylap,tennhanvien,tenkhachhang



select mahoadon,sum(soluong*Gia)
from monan inner join ChiTietHoaDon on ChiTietHoaDon.MaMonAn=MonAn.MaMonAn
group by MaHoaDon

select distinct mota from MonAn

select * from monan where MoTa=N'nấu'

select tenmonan,gia,monan.mota,menu.TenMenu from monan,menu where MonAn.mamenu=menu.mamenu and menu.mamenu='mnu1'

select tenmenu,tenmonan,soluong from monan,chitiethoadon,menu
where monan.mamonan=chitiethoadon.mamonan
     and menu.mamenu=monan.mamenu
      and mahoadon='hdn1'