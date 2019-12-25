using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebQLXeMay.Models
{
    public class KhachHang
    {
        [Key]
        [Required(ErrorMessage = "Mã khách hàng không được bỏ trống")]
        [DisplayName("Mã khách hàng")]
        public string MaKH { get; set; }

        [Required(ErrorMessage = "Tên khách hàng không được bỏ trống")]
        [DisplayName("Tên khách hàng")]
        public string TenKH { get; set; }

        [Required(ErrorMessage = "Chưa lựa chọn giới tính")]
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [DisplayName("Số điện thoại")]
        [MaxLength(10, ErrorMessage = "Phải là 10 số")]
        [MinLength(10, ErrorMessage = "Phải là 10 số")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
    }
}
