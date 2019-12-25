using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebQLXeMay.Models
{
    public class HDNhap
    {
        [Key]
        [DisplayName("Mã hóa đơn")]
        [Required(ErrorMessage = "Mã hóa đơn không được bỏ trống")]
        public string MaHoaDon { get; set; }

        [Required(ErrorMessage = "Thông tin xe không được bỏ trống")]
        public string MaXe { get; set; }

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

        [DisplayName("Thuế giá trị gia tăng")]
        [Required(ErrorMessage = "Thuế GTGT không được bỏ trống")]
        public int ThueGTGT { get; set; }

        public decimal ThanhTien { get; }

        [DisplayName("Màu sắc")]
        [Required(ErrorMessage = "Màu sắc không được bỏ trống")]
        public string MauSac { get; set; }
    }

    public class HDNhapShow
    {
        [DisplayName("Mã hóa đơn")]
        public string MaHoaDon { get; set; }
        [DisplayName("Tên xe máy")]
        public string TenXe { get; set; }

        [DisplayName("Tên nhân viên")]
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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal ThanhTien { get; set; }
        [DisplayName("Màu sắc")]
        public string MauSac { get; set; }
    }
}
