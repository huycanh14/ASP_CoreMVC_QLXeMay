using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebQLXeMay.Models
{
    public class HDXuat
    {
        [Key]
        public string MaHoaDon { get; set; }
        public string MaXe { get; set; }
        public string MaKH { get; set; }
        public string MaNhanVien { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime NgayLap { get; set; }
        public int ThueGTGT { get; set; }
        public decimal ThanhTien { get; }
        public string MauSac { get; set; }
        public int SoKhung { get; set; }
        public int SoMay { get; set; }
        public int BaoHanh { get; set; }
    }
}
