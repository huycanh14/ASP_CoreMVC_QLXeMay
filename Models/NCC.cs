using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebQLXeMay.Models
{
    public class NCC
    {
        [Key]
        [DisplayName("Mã Nhà cung cấp")]
        [Required(ErrorMessage = "Mã Nhà cung cấp không để trống")]
        public string MaNCC { get; set; }

        [DisplayName("Tên Nhà cung cấp")]
        [Required(ErrorMessage = "Tên Nhà cung cấp không để trống")]
        public string TenNCC { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không để trống")]
        [MaxLength(10, ErrorMessage= "Phải là 10 chữ số")]
        [MinLength(10, ErrorMessage = "Phải là 10 chữ số")]
        public string SDT { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không để trống")]
        public string DiaChi { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không để trống")]
        public string Email { get; set; }
    }
}
