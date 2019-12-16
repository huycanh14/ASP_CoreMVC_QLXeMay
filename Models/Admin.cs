using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebQLXeMay.Models
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
    }
}
