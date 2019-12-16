using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebQLXeMay.Models
{
    public class XeMay
    {
        [Key]
        public string MaXe { get; set; }
        public string TenXe { get; set; }
        public string MaNCC { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public string MauSac { get; set; }
    }
}
