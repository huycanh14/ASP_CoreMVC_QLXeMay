using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebQLXeMay.Models
{
    public class HDXuat
    {
        [Key]
        [Required(ErrorMessage = "Mã hóa đơn không được bỏ trống")]
        [DisplayName("Mã hóa đơn")]
        public string MaHoaDon { get; set; }

        public string MaXe { get; set; }
        public string MaKH { get; set; }
        public string MaNhanVien { get; set; }

        [Required(ErrorMessage = "Đơn giá không được bỏ trống")]
        public decimal DonGia { get; set; }

        [Required(ErrorMessage = "Số lượng không được bỏ trống")]
        public int SoLuong { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime NgayLap { get; set; }

        [Required(ErrorMessage = "Thuế giá trị gia tăng không được bỏ trống")]
        public int ThueGTGT { get; set; }
        public decimal ThanhTien { get; set; }
        public string MauSac { get; set; }
        public int SoKhung { get; set; }
        public int SoMay { get; set; }
        public int BaoHanh { get; set; }
    }

    public class HDXuatShow
    {
        [DisplayName("Mã hóa đơn")]
        public string MaHoaDon { get; set; }
        [DisplayName("Tên xe máy")]
        public string TenXe { get; set; }
        [DisplayName("Tên khách hàng")]
        public string TenKH { get; set; }
        [DisplayName("Tê nhân viên")]
        public string TenNhanVien { get; set; }
        [DisplayName("Đơn giá")]
        public decimal DonGia { get; set; }
        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }
        [DisplayName("Ngày mua")]
        public DateTime NgayLap { get; set; }
        [DisplayName("Thuế giá trị gia tăng")]
        public int ThueGTGT { get; set; }
        [DisplayName("Tổng tiền")]
        public decimal ThanhTien { get; set; }
        [DisplayName("Màu sắc")]
        public string MauSac { get; set; }
        [DisplayName("Số khung")]
        public int SoKhung { get; set; }
        [DisplayName("Số máy")]
        public int SoMay { get; set; }
        [DisplayName("Số máy")]
        public int BaoHanh { get; set; }
    }
}
