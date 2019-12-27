USE [master]
GO
/****** Object:  Database [db_WebsiteQLXeMay]    Script Date: 27/12/2019 16:13:24 ******/
CREATE DATABASE [db_WebsiteQLXeMay]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyBanXeMay', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\QuanLyBanXeMay.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyBanXeMay_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\QuanLyBanXeMay_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_WebsiteQLXeMay].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET RECOVERY FULL 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET  MULTI_USER 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET QUERY_STORE = OFF
GO
USE [db_WebsiteQLXeMay]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[HoVaTen] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HDNhaps]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HDNhaps](
	[MaHoaDon] [varchar](50) NOT NULL,
	[MaXe] [varchar](50) NOT NULL,
	[MaNhanVien] [varchar](50) NOT NULL,
	[DonGia] [money] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[NgayLap] [datetime] NOT NULL,
	[ThueGTGT] [int] NOT NULL,
	[ThanhTien]  AS ([DonGia]*[SoLuong]+(([DonGia]*[SoLuong])*[ThueGTGT])/(100)),
	[MauSac] [nvarchar](50) NULL,
 CONSTRAINT [PK_HDNhap_1] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HDXuats]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HDXuats](
	[MaHoaDon] [varchar](50) NOT NULL,
	[MaXe] [varchar](50) NOT NULL,
	[MaNhanVien] [varchar](50) NOT NULL,
	[MaKH] [varchar](50) NOT NULL,
	[DonGia] [money] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[NgayLap] [datetime] NOT NULL,
	[ThueGTGT] [int] NOT NULL,
	[ThanhTien]  AS ([DonGia]*[SoLuong]+(([DonGia]*[SoLuong])*[ThueGTGT])/(100)),
	[MauSac] [nvarchar](50) NULL,
	[SoKhung] [int] NULL,
	[SoMay] [int] NULL,
	[BaoHanh] [int] NULL,
 CONSTRAINT [PK_HDXuat_1] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHangs]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHangs](
	[MaKH] [varchar](50) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](5) NOT NULL,
	[SDT] [nvarchar](15) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCCs]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCCs](
	[MaNCC] [varchar](50) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_NCC] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanViens]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanViens](
	[MaNhanVien] [varchar](50) NOT NULL,
	[TenNhanVien] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](5) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [nvarchar](15) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XeMays]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XeMays](
	[MaXe] [varchar](50) NOT NULL,
	[TenXe] [nvarchar](50) NOT NULL,
	[MaNCC] [varchar](50) NOT NULL,
	[DonGia] [money] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[MauSac] [nvarchar](50) NULL,
 CONSTRAINT [PK_XeMay] PRIMARY KEY CLUSTERED 
(
	[MaXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([ID], [TenDangNhap], [MatKhau], [HoVaTen], [NgaySinh], [GioiTinh]) VALUES (1, N'admin', N'12345', N'Đặng Huy Cảnh', CAST(N'1998-07-14' AS Date), N'Nam')
SET IDENTITY_INSERT [dbo].[Admins] OFF
INSERT [dbo].[HDNhaps] ([MaHoaDon], [MaXe], [MaNhanVien], [DonGia], [SoLuong], [NgayLap], [ThueGTGT], [MauSac]) VALUES (N'HDN1', N'XM01', N'NV2', 50000000.0000, 10, CAST(N'2018-12-22T08:28:35.070' AS DateTime), 10, N'Trắng, đen, đỏ')
INSERT [dbo].[HDNhaps] ([MaHoaDon], [MaXe], [MaNhanVien], [DonGia], [SoLuong], [NgayLap], [ThueGTGT], [MauSac]) VALUES (N'HDN2', N'XM10', N'NV2', 29000000.0000, 10, CAST(N'2018-12-22T08:29:20.670' AS DateTime), 10, N'TRắng xám')
INSERT [dbo].[HDNhaps] ([MaHoaDon], [MaXe], [MaNhanVien], [DonGia], [SoLuong], [NgayLap], [ThueGTGT], [MauSac]) VALUES (N'HDN3', N'XM11', N'NV2', 40000000.0000, 10, CAST(N'2018-12-22T08:30:21.940' AS DateTime), 10, N'Xanh')
INSERT [dbo].[HDNhaps] ([MaHoaDon], [MaXe], [MaNhanVien], [DonGia], [SoLuong], [NgayLap], [ThueGTGT], [MauSac]) VALUES (N'HDN4', N'XM04', N'NV2', 80000000.0000, 10, CAST(N'2018-12-22T08:33:56.850' AS DateTime), 10, N'Đỏ')
INSERT [dbo].[HDXuats] ([MaHoaDon], [MaXe], [MaNhanVien], [MaKH], [DonGia], [SoLuong], [NgayLap], [ThueGTGT], [MauSac], [SoKhung], [SoMay], [BaoHanh]) VALUES (N'HDX1', N'XM01', N'NV1', N'KH1', 51690000.0000, 1, CAST(N'2018-12-22T08:07:21.753' AS DateTime), 10, N'Đỏ', 98767, 45676, 36)
INSERT [dbo].[HDXuats] ([MaHoaDon], [MaXe], [MaNhanVien], [MaKH], [DonGia], [SoLuong], [NgayLap], [ThueGTGT], [MauSac], [SoKhung], [SoMay], [BaoHanh]) VALUES (N'HDX2', N'XM07', N'NV5', N'KH2', 560000000.0000, 2, CAST(N'2018-12-22T08:09:23.603' AS DateTime), 10, N'Xám', 32345, 54344, 36)
INSERT [dbo].[HDXuats] ([MaHoaDon], [MaXe], [MaNhanVien], [MaKH], [DonGia], [SoLuong], [NgayLap], [ThueGTGT], [MauSac], [SoKhung], [SoMay], [BaoHanh]) VALUES (N'HDX3', N'XM01', N'NV1', N'KH1', 51690000.0000, 1, CAST(N'2019-12-19T11:18:38.080' AS DateTime), 10, N'Đen', 53435, 35355, 36)
INSERT [dbo].[HDXuats] ([MaHoaDon], [MaXe], [MaNhanVien], [MaKH], [DonGia], [SoLuong], [NgayLap], [ThueGTGT], [MauSac], [SoKhung], [SoMay], [BaoHanh]) VALUES (N'HDX4', N'XM01', N'NV1', N'KH1', 51690000.0000, 1, CAST(N'2019-12-18T00:00:00.000' AS DateTime), 10, N'Nâu', 22431, 14235, 36)
INSERT [dbo].[HDXuats] ([MaHoaDon], [MaXe], [MaNhanVien], [MaKH], [DonGia], [SoLuong], [NgayLap], [ThueGTGT], [MauSac], [SoKhung], [SoMay], [BaoHanh]) VALUES (N'HDX5', N'XM02', N'NV2', N'KH2', 51690000.0000, 7, CAST(N'2019-12-17T00:00:00.000' AS DateTime), 10, N'Trắng Xám', 11135, 14531, 36)
INSERT [dbo].[HDXuats] ([MaHoaDon], [MaXe], [MaNhanVien], [MaKH], [DonGia], [SoLuong], [NgayLap], [ThueGTGT], [MauSac], [SoKhung], [SoMay], [BaoHanh]) VALUES (N'HDX6', N'XM10', N'NV5', N'KH2', 22000000.0000, 1, CAST(N'2019-12-24T12:51:20.000' AS DateTime), 10, N'Trắng xám', 26354, 521234, 32)
INSERT [dbo].[KhachHangs] ([MaKH], [TenKH], [GioiTinh], [SDT], [DiaChi]) VALUES (N'KH1', N'Ngô Văn Báu', N'Nam', N'0983647892', N'Hà Nội')
INSERT [dbo].[KhachHangs] ([MaKH], [TenKH], [GioiTinh], [SDT], [DiaChi]) VALUES (N'KH2', N'Lê Thị Hòa', N'Nữ', N'0936243678', N'Hà Nội')
INSERT [dbo].[NCCs] ([MaNCC], [TenNCC], [SDT], [DiaChi], [Email]) VALUES (N'NCC1', N'HonDa', N'02113868888', N'ZIP CODE, Hai Bà Trưng, Phường Phúc Thắng, Phúc Yên, Vĩnh Phúc', N'cr@honda.com.vn')
INSERT [dbo].[NCCs] ([MaNCC], [TenNCC], [SDT], [DiaChi], [Email]) VALUES (N'NCC2', N'Yamaha', N'02437280080', N'164 Hoàng Hoa Thám, Thuỵ Khuê, Tây Hồ, Hà Nội', N'hd@gmail.com')
INSERT [dbo].[NCCs] ([MaNCC], [TenNCC], [SDT], [DiaChi], [Email]) VALUES (N'NCC3', N'Piaggio', N'0437921238', N'72-74 Hồ Tùng Mậu,P.Mai Dịch,Q.Từ L
100000 Hà Nội, HN', N'piaggio@gmail.com')
INSERT [dbo].[NCCs] ([MaNCC], [TenNCC], [SDT], [DiaChi], [Email]) VALUES (N'NCC4', N'Suzuki', N'02438235235', N'Đường số 2, KCN Long Bình, P. Long Bình, Tp. Biên Hòa, Đồng Nai', N'suzuki@gmail.com')
INSERT [dbo].[NCCs] ([MaNCC], [TenNCC], [SDT], [DiaChi], [Email]) VALUES (N'NCC5', N'Sym', N'0942120066', N'77 Khâm Thiên, Đống Đa, Hà Nội', N'sym@gmail.com')
INSERT [dbo].[NhanViens] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi], [SDT]) VALUES (N'NV1', N'Trần Văn Bình', N'Nam', CAST(N'1990-07-12' AS Date), N'23 Nguyễn Bỉnh Khiên, Hà Nội', N'0987696784')
INSERT [dbo].[NhanViens] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi], [SDT]) VALUES (N'NV2', N'Lê Thị Ánh', N'Nữ', CAST(N'1989-09-06' AS Date), N'76 Ngô Gia Tự, Hà Nội', N'0982335748')
INSERT [dbo].[NhanViens] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi], [SDT]) VALUES (N'NV3', N'Ngô Thị Ngọc Bính', N'Nữ', CAST(N'1992-09-09' AS Date), N'34 Phố Huế, Hà Nội', N'0935627334')
INSERT [dbo].[NhanViens] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi], [SDT]) VALUES (N'NV4', N'Đặng Văn Thắng', N'Nam', CAST(N'1991-03-07' AS Date), N'Hà Nội', N'0345682829')
INSERT [dbo].[NhanViens] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi], [SDT]) VALUES (N'NV5', N'Ngô Văn Bình', N'Nam', CAST(N'1993-05-27' AS Date), N'Hà Nội', N'0876346513')
INSERT [dbo].[NhanViens] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi], [SDT]) VALUES (N'NV6', N'Lê Đức Tài', N'Nam', CAST(N'1992-04-23' AS Date), N'Hà Nội', N'0763752323')
INSERT [dbo].[NhanViens] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi], [SDT]) VALUES (N'NV7', N'Trần Đăng Quang', N'Nam', CAST(N'1996-03-09' AS Date), N'Hà Nội', N'0988724134')
INSERT [dbo].[NhanViens] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi], [SDT]) VALUES (N'NV8', N'Ông Gia Báu', N'Nam', CAST(N'1994-02-09' AS Date), N'Hà Nội', N'0987676273')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM01', N'SH MODE 125CC', N'NCC1', 51690000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM02', N'SH125/150i', N'NCC1', 67990000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM03', N'WINNER 150cc', N'NCC1', 45490000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM04', N'Super Cub C125', N'NCC1', 84990000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM05', N'MSX 125cc', N'NCC1', 49990000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM06', N'Gold Wing', N'NCC1', 1200000000.0000, 5, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM07', N'CBR1000RR Fireblade/Fireblade SP', N'NCC1', 560000000.0000, 5, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM08', N'Wave Alpha 110cc', N'NCC1', 17790000.0000, 15, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM09', N'Blade 110cc', N'NCC1', 1880000.0000, 15, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM10', N'Future 125cc', N'NCC1', 30190000.0000, 15, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM11', N'Exciter 150 GP', N'NCC2', 47490000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM12', N'Jupiter FI GP', N'NCC2', 30000000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM13', N'Sirius phanh đĩa', N'NCC2', 19800000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM14', N'Sirius RC vành đúc', N'NCC2', 21300000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM15', N'

Grande (Blue Core Hybrid)', N'NCC2', 50000000.0000, 15, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM16', N'NVX 155 ABS', N'NCC2', 52740000.0000, 15, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM17', N'MT-03', N'NCC2', 139000000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM18', N'NM-X', N'NCC2', 82000000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM19', N'YZF-R15', N'NCC2', 79000000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM2', N'Wave', N'NCC1', 22000000.0000, 23, N'Trắng, đỏ')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM20', N'YZF-R3', N'NCC2', 139000000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM21', N'Liberty 125 ABS', N'NCC3', 57500000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM22', N'Xe Máy Vespa GTS 125cc ABS - Trắng', N'NCC3', 93900000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM23', N'Vespa LX I-Get - Trắng', N'NCC3', 67900000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM24', N'Liberty Italia', N'NCC3', 58500000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM25', N'Zip 100 E3', N'NCC3', 36000000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM26', N'GSX-S150', N'NCC4', 69400000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM27', N'GSX-S150', N'NCC4', 69800000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM28', N'AXELO 125', N'NCC4', 23990000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM29', N'
VIVA 115 Fi', N'NCC4', 2269000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM30', N'REVO 110', N'NCC4', 17690000.0000, 15, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM31', N'

Abela 110', N'NCC5', 25490000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM32', N'Husky Classic 125', N'NCC5', 31900000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM33', N'Fancy 125 EFI (bản ABS)', N'NCC5', 38900000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM34', N'Fancy 125 EFI (bản tiêu chuẩn)', N'NCC5', 35900000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
INSERT [dbo].[XeMays] ([MaXe], [TenXe], [MaNCC], [DonGia], [SoLuong], [MauSac]) VALUES (N'XM36', N'Angel 110', N'NCC5', 15490000.0000, 10, N'Đỏ, đen, trắng, trắng xám, xanh')
ALTER TABLE [dbo].[HDNhaps] ADD  CONSTRAINT [DF_HDNhap_NgayLap]  DEFAULT (getdate()) FOR [NgayLap]
GO
ALTER TABLE [dbo].[HDNhaps] ADD  CONSTRAINT [DF_HDNhap_ThueGTGT]  DEFAULT ((10)) FOR [ThueGTGT]
GO
ALTER TABLE [dbo].[HDXuats] ADD  CONSTRAINT [DF_HDXuat_NgayLap]  DEFAULT (getdate()) FOR [NgayLap]
GO
ALTER TABLE [dbo].[HDXuats] ADD  CONSTRAINT [DF_HDXuat_ThueGTGT]  DEFAULT ((10)) FOR [ThueGTGT]
GO
ALTER TABLE [dbo].[HDNhaps]  WITH CHECK ADD  CONSTRAINT [FK_HDNhap_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanViens] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HDNhaps] CHECK CONSTRAINT [FK_HDNhap_NhanVien]
GO
ALTER TABLE [dbo].[HDNhaps]  WITH CHECK ADD  CONSTRAINT [FK_HDNhap_XeMay] FOREIGN KEY([MaXe])
REFERENCES [dbo].[XeMays] ([MaXe])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HDNhaps] CHECK CONSTRAINT [FK_HDNhap_XeMay]
GO
ALTER TABLE [dbo].[HDXuats]  WITH CHECK ADD  CONSTRAINT [FK_HDXuat_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHangs] ([MaKH])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HDXuats] CHECK CONSTRAINT [FK_HDXuat_KhachHang]
GO
ALTER TABLE [dbo].[HDXuats]  WITH CHECK ADD  CONSTRAINT [FK_HDXuat_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanViens] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HDXuats] CHECK CONSTRAINT [FK_HDXuat_NhanVien]
GO
ALTER TABLE [dbo].[HDXuats]  WITH CHECK ADD  CONSTRAINT [FK_HDXuat_XeMay] FOREIGN KEY([MaXe])
REFERENCES [dbo].[XeMays] ([MaXe])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HDXuats] CHECK CONSTRAINT [FK_HDXuat_XeMay]
GO
ALTER TABLE [dbo].[XeMays]  WITH CHECK ADD  CONSTRAINT [FK_XeMay_NCC] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NCCs] ([MaNCC])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[XeMays] CHECK CONSTRAINT [FK_XeMay_NCC]
GO
ALTER TABLE [dbo].[HDNhaps]  WITH CHECK ADD  CONSTRAINT [CK_HDNhap] CHECK  (([NgayLap]<=getdate()))
GO
ALTER TABLE [dbo].[HDNhaps] CHECK CONSTRAINT [CK_HDNhap]
GO
ALTER TABLE [dbo].[HDXuats]  WITH CHECK ADD  CONSTRAINT [CK_HDXuat] CHECK  (([NgayLap]<=getdate()))
GO
ALTER TABLE [dbo].[HDXuats] CHECK CONSTRAINT [CK_HDXuat]
GO
/****** Object:  StoredProcedure [dbo].[BaoCaoHDNhapTheoTGian]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[BaoCaoHDNhapTheoTGian] (@BatDau date, @KetThuc date)
as

select HDNhap.MaXe[Mã xe], XeMay.TenXe[Tên xe],sum(HDNhap.SoLuong)[Số lượng], 
sum(HDNhap.ThanhTien)[Thành tiền]
from HDNhap
inner join XeMay on XeMay.MaXe = HDNhap.MaXe
where HDNhap.NgayLap >= @BatDau and HDNhap.NgayLap <= @KetThuc
group by HDNhap.MaXe, XeMay.TenXe
GO
/****** Object:  StoredProcedure [dbo].[BaoCaoHDXuatTheoTGian]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[BaoCaoHDXuatTheoTGian] (@BatDau date, @KetThuc date)
as

select HDXuat.MaXe[Mã xe], XeMay.TenXe[Tên xe],sum(HDXuat.SoLuong)[Số lượng], 
sum(HDXuat.ThanhTien)[Thành tiền]
from HDXuat
inner join XeMay on XeMay.MaXe = HDXuat.MaXe
where HDXuat.NgayLap >= @BatDau and HDXuat.NgayLap <= @KetThuc
group by HDXuat.MaXe, XeMay.TenXe
GO
/****** Object:  StoredProcedure [dbo].[DanhSachHDNhap]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DanhSachHDNhap]
as
select MaHoaDon[Mã hóa đơn], MaXe[Mã xe] ,MaNCC[Mã nhà cung cấp], MaNhanVien[Mã nhân viên], DonGia[Đơn giá], SoLuong[Số lượng],
NgayLap[Ngày Lập], ThueGTGT[Thuế GTGT], ThanhTien[Thành tiền] 
from HDNhap
order by NgayLap desc
GO
/****** Object:  StoredProcedure [dbo].[DanhSachHDXuat]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DanhSachHDXuat]
as
select MaHoaDon[Mã hóa đơn], MaXe[Mã xe] ,MaKH[Mã khách hàng], MaNhanVien[Mã nhân viên], DonGia[Đơn giá], SoLuong[Số lượng],
NgayLap[Ngày Lập], ThueGTGT[Thuế GTGT], ThanhTien[Thành tiền] 
from HDXuat
order by NgayLap desc 
GO
/****** Object:  StoredProcedure [dbo].[DanhSachKhachHangTrongDataGridView]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DanhSachKhachHangTrongDataGridView]
as
select MaKH[Mã khách hàng],TenKH[Tên khách hàng],GioiTinh[Giới tính],SDT[Số điện thoại],DiaChi[Địa chỉ] from KhachHang
GO
/****** Object:  StoredProcedure [dbo].[DanhSachNhaCungCap]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DanhSachNhaCungCap]
as
select MaNCC[Mã nhà cung cấp],TenNCC[Tên nhà cung cấp],SDT[Số điện thoại],DiaChi[Địa Chỉ],Email[Email] from NCC
GO
/****** Object:  StoredProcedure [dbo].[DanhSachNhanVien]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DanhSachNhanVien]
as
select MaNhanVien[Mã nhân viên], TenNhanVien[Tên Nhân Viên], GioiTinh[Giới Tính], NgaySinh[Ngày Sinh], 
DiaChi[Địa Chỉ],SDT[Số điện thoại]
 from NhanVien
GO
/****** Object:  StoredProcedure [dbo].[DanhSachXeMay]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DanhSachXeMay]
as
select XeMay.MaXe[Mã xe],XeMay.TenXe[Tên xe], XeMay.MaNCC[Mã nhà cung cấp],NCC.TenNCC[Tên nhà cung cấp],
XeMay.DonGia[Đơn giá],XeMay.SoLuong[Số lượng] from XeMay
inner join NCC on NCC.MaNCC = XeMay.MaNCC
GO
/****** Object:  StoredProcedure [dbo].[KiemTraDangNhap]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[KiemTraDangNhap] 
(@TenDangNhap nvarchar(50),
@MatKhau nvarchar(50))
as
select * from Admin where TenDangNhap = @TenDangNhap and MatKhau = @MatKhau
GO
/****** Object:  StoredProcedure [dbo].[SuaHDNhap]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SuaHDNhap]
(@MaHoaDon varchar(50),
@MaXe varchar(50),
@MaNCC varchar(50),
@MaNhanVien varchar(50),
@DonGia money,
@SoLuong int,
@NgayLap datetime,
@ThueGTGT int)
as
update HDNhap set
MaXe = @MaXe, MaNCC= @MaNCC, MaNhanVien = MaNhanVien, DonGia = @DonGia, SoLuong = @SoLuong, NgayLap = @NgayLap,
ThueGTGT = @ThueGTGT 
where MaHoaDon = @MaHoaDon
GO
/****** Object:  StoredProcedure [dbo].[SuaHDXuat]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SuaHDXuat]
(@MaHoaDon varchar(50),
@MaXe varchar(50),
@MaKH varchar(50),
@MaNhanVien varchar(50),
@DonGia money,
@SoLuong int,
@NgayLap datetime,
@ThueGTGT int)
as
update HDXuat set
MaXe = @MaXe, MaKH= @MaKH, MaNhanVien = MaNhanVien, DonGia = @DonGia, SoLuong = @SoLuong, NgayLap = @NgayLap,
ThueGTGT = @ThueGTGT 
where MaHoaDon = @MaHoaDon
GO
/****** Object:  StoredProcedure [dbo].[SuaKhachHang]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SuaKhachHang]
(@MaKH varchar(50),
@TenKH nvarchar(50),
@GioiTinh nvarchar(5),
@SDT nvarchar(15),
@DiaChi nvarchar(50))
as
update KhachHang set TenKH = @TenKH, GioiTinh = @GioiTinh, SDT = @SDT, DiaChi = @DiaChi
where MaKH = @MaKH
GO
/****** Object:  StoredProcedure [dbo].[SuaNhaCungCap]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SuaNhaCungCap]
(@MaNCC varchar(50),
@TenNCC nvarchar(50),
@SDT varchar(50),
@DiaChi nvarchar(100),
@Email nvarchar(50))
as
update NCC set TenNCC = @TenNCC, SDT  = @SDT, DiaChi = @DiaChi, Email = @Email 
where MaNCC = @MaNCC
GO
/****** Object:  StoredProcedure [dbo].[SuaNhanVien]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SuaNhanVien]
(@MaNhanVien varchar(50),
@TenNhanVien nvarchar(50),
@GioiTinh nvarchar(5),
@NgaySinh date,
@SDT nvarchar(15),
@DiaChi nvarchar(50))
as
update NhanVien set TenNhanVien = @TenNhanVien, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, SDT = @SDT, DiaChi = @DiaChi
where MaNhanVien = @MaNhanVien
GO
/****** Object:  StoredProcedure [dbo].[SuaXeMay]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SuaXeMay]
(@MaXe varchar(50),
@TenXe nvarchar(50),
@MaNCC varchar(50),
@DonGia	money,
@SoLuong int)
as
update XeMay set TenXe = @TenXe, MaNCC = @MaNCC, DonGia = @DonGia, SoLuong = @SoLuong
where MaXe = @MaXe
GO
/****** Object:  StoredProcedure [dbo].[ThayDoiMatKhau]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThayDoiMatKhau]
(@ID int,
@MatKhau nvarchar(50))
as
update Admin set MatKhau = @MatKhau where ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[ThemHDNhap]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemHDNhap]
(@MaHoaDon varchar(50),
@MaXe varchar(50),
@MaNCC varchar(50),
@MaNhanVien varchar(50),
@DonGia money,
@SoLuong int,
@NgayLap datetime,
@ThueGTGT int)
as
insert into HDNhap (MaHoaDon, MaXe, MaNCC, MaNhanVien, DonGia, SoLuong, NgayLap, ThueGTGT)
values (@MaHoaDon, @MaXe, @MaNCC, @MaNhanVien, @DonGia, @SoLuong, @NgayLap, @ThueGTGT)
GO
/****** Object:  StoredProcedure [dbo].[ThemHDXuat]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemHDXuat]
(@MaHoaDon varchar(50),
@MaXe varchar(50),
@MaKH varchar(50),
@MaNhanVien varchar(50),
@DonGia money,
@SoLuong int,
@NgayLap datetime,
@ThueGTGT int)
as
insert into HDXuat(MaHoaDon, MaXe, MaKH, MaNhanVien, DonGia, SoLuong, NgayLap, ThueGTGT)
values (@MaHoaDon, @MaXe, @MaKH, @MaNhanVien, @DonGia, @SoLuong, @NgayLap, @ThueGTGT)
GO
/****** Object:  StoredProcedure [dbo].[ThemKhachHang]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemKhachHang]
(@MaKH varchar(50),
@TenKH nvarchar(50),
@GioiTinh nvarchar(5),
@SDT nvarchar(15),
@DiaChi nvarchar(50))
as
insert into KhachHang (MaKH, TenKH, GioiTinh, SDT, DiaChi)
values (@MaKH, @TenKH, @GioiTinh, @SDT, @DiaChi) 
GO
/****** Object:  StoredProcedure [dbo].[ThemNhaCungCap]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemNhaCungCap]
(@MaNCC varchar(50),
@TenNCC nvarchar(50),
@SDT varchar(50),
@DiaChi nvarchar(100),
@Email nvarchar(50))
as
insert into NCC (MaNCC, TenNCC, SDT, DiaChi, Email)
values (@MaNCC, @TenNCC, @SDT, @DiaChi, @Email)
GO
/****** Object:  StoredProcedure [dbo].[ThemNhanVien]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[ThemNhanVien]
(@MaNhanVien varchar(50),
@TenNhanVien nvarchar(50),
@GioiTinh nvarchar(5),
@NgaySinh date,
@SDT nvarchar(15),
@DiaChi nvarchar(50))
as
insert into NhanVien (MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, SDT, DiaChi)
values (@MaNhanVien, @TenNhanVien, @GioiTinh, @NgaySinh, @SDT, @DiaChi)
GO
/****** Object:  StoredProcedure [dbo].[ThemXeMay]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemXeMay]
(@MaXe varchar(50),
@TenXe nvarchar(50),
@MaNCC varchar(50),
@DonGia	money,
@SoLuong int)
as
insert into XeMay (MaXe, TenXe, MaNCC, DonGia, SoLuong)
values (@MaXe, @TenXe, @MaNCC, @DonGia, @SoLuong)
GO
/****** Object:  StoredProcedure [dbo].[XoaHDNhap]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaHDNhap]
(@MaHoaDon varchar(50))
as
delete from HDNhap where MaHoaDon = @MaHoaDon
GO
/****** Object:  StoredProcedure [dbo].[XoaHDXuat]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaHDXuat]
(@MaHoaDon varchar(50))
as
delete from HDNhap where MaHoaDon = @MaHoaDon
GO
/****** Object:  StoredProcedure [dbo].[XoaKhachHang]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaKhachHang]
(@MaKH varchar(50))
as
delete from KhachHang where MaKH = @MaKH
GO
/****** Object:  StoredProcedure [dbo].[XoaNhaCungCap]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaNhaCungCap]
(@MaNCC varchar(50))
as
delete from NCC where MaNCC = @MaNCC
GO
/****** Object:  StoredProcedure [dbo].[XoaNhanVien]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaNhanVien]
(@MaNhanVien varchar(50))
as
delete from NhanVien where MaNhanVien = @MaNhanVien
GO
/****** Object:  StoredProcedure [dbo].[XoaXeMay]    Script Date: 27/12/2019 16:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaXeMay]
(@MaXe varchar(50))
as
delete from XeMay where MaXe = @MaXe
GO
USE [master]
GO
ALTER DATABASE [db_WebsiteQLXeMay] SET  READ_WRITE 
GO
