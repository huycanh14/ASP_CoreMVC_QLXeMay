using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebQLXeMay.Models
{
    public class XeMay
    {
        [Key]
        [Required(ErrorMessage = "Mã xe bạn đang để trống")]
        [DisplayName("Mã xe")]
        public string MaXe { get; set; }

        [Required(ErrorMessage = "Tên xe bạn đang bỏ trống")]
        [DisplayName("Tên xe")]
        public string TenXe { get; set; }

        [Required(ErrorMessage = "Thông tin nhà cung cấp đang bỏ trống")]
        public string MaNCC { get; set; }

        [Required(ErrorMessage = "Đơn giá đang bỏ trống")]
        [DisplayName("Đơn giá")]
        public decimal DonGia { get; set; }

        [Required(ErrorMessage = "Số lượng bạn đang bỏ trống")]
        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Màu sắc bạn đang bỏ trống")]
        [DisplayName("Màu sắc")]
        public string MauSac { get; set; }
    }

    public class XeMayShow
    {
        [DisplayName("Mã xe")]
        public string MaXe { get; set; }

        [DisplayName("Tên xe")]
        public string TenXe { get; set; }

        [DisplayName("Tên nhà cung cấp")]
        public string TenNCC { get; set; }

        [DisplayName("Đơn giá")]
        public decimal DonGia { get; set; }

        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }

        [DisplayName("Màu sắc")]
        public string MauSac { get; set; }
    }
}
