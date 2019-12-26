using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebQLXeMay.Models
{
    public class Admin
    {
        [Key]
        [DisplayName("Mã tài khoản")]
        public int ID { get; set; }

        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống")]
        public string TenDangNhap { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string MatKhau { get; set; }

        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không đưuọc bỏ trống")]
        public string HoVaTen { get; set; }

        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được bỏ trống")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Giới tính không được bỏ trống")]
        public string GioiTinh { get; set; }
    }
}
