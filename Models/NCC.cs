using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebQLXeMay.Models
{
    public class NCC
    {
        [Key]
        [Required(ErrorMessage = "Mã Nhà cung cấp không để trống")]
        public string MaNCC { get; set; }
        [Required(ErrorMessage = "Tên Nhà cung cấp không để trống")]
        public string TenNCC { get; set; }
        [Required(ErrorMessage = "Số điện thoại không để trống")]
        [MaxLength(10, ErrorMessage= "Phải là 10 chữ số")]
        [MinLength(10, ErrorMessage = "Phải là 10 chữ số")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Địa chỉ không để trống")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Email không để trống")]
        public string Email { get; set; }
    }
}
