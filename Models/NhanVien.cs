using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebQLXeMay.Models
{
    public class NhanVien
    {
        [Key]
        [Required(ErrorMessage = "Mã nhân viên không được bỏ trống")]
        [DisplayName("Mã nhân viên")]
        public string MaNhanVien { get; set; }

        [Required(ErrorMessage = "Tên nhân viên không được bỏ trống")]
        [DisplayName("Tên nhân viên")]
        public string TenNhanVien { get; set; }

        [Required(ErrorMessage = "Giới tính nhân viên không được bỏ trống")]
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Ngày sinh không được bỏ trống")]
        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [DisplayName("Số điện thoại")]
        [MaxLength(10, ErrorMessage = "Phải là 10 số")]
        [MinLength(10, ErrorMessage = "Phải là 10 số")]
        public string SDT { get; set; }
    }
}
