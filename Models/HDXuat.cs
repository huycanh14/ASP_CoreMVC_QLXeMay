using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required(ErrorMessage = "Thông tin xe không được bỏ trống")]
        public string MaXe { get; set; }

        [Required(ErrorMessage = "Thông tin khách hàng không được bỏ trống")]
        public string MaKH { get; set; }

        [Required(ErrorMessage = "Thông tin nhân viên không được bỏ trống")]
        public string MaNhanVien { get; set; }

        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = "Đơn giá không được bỏ trống")]
        public decimal DonGia { get; set; }

        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Số lượng không được bỏ trống")]
        public int SoLuong { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime NgayLap { get; set; }

        [Required(ErrorMessage = "Thuế giá trị gia tăng không được bỏ trống")]
        [DisplayName("Thuế giá trị gia tăng")]
        public int ThueGTGT { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal ThanhTien { get; set; }

        [DisplayName("Màu săc")]
        [Required(ErrorMessage = "Màu sắc của xe không được bỏ trống")]
        public string MauSac { get; set; }

        [Required(ErrorMessage = "Số khung của xe không được bỏ trống")]
        [DisplayName("Số khung")]
        public int SoKhung { get; set; }

        [Required(ErrorMessage = "Số máy của xe không được bỏ trống")]
        [DisplayName("Số máy")]
        public int SoMay { get; set; }

        [Required(ErrorMessage = "Bảo hành của xe không được bỏ trống")]
        [DisplayName("Bảo hành")]
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
        [DisplayName("Thời gian bảo hành")]
        public int BaoHanh { get; set; }
    }
}
