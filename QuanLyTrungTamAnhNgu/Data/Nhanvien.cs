using System;
using System.Collections.Generic;

namespace QuanLyTrungTamAnhNgu.Data;

public partial class Nhanvien
{
    public int Manv { get; set; }

    public string? Tennv { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Gioitinh { get; set; }

    public string? Diachi { get; set; }

    public string? Socccd { get; set; }

    public int? Sdt { get; set; }

    public string? Email { get; set; }

    public string? Chucvu { get; set; }

    public virtual ICollection<Bangluong> Bangluongs { get; set; } = new List<Bangluong>();

    public virtual ICollection<Hoadonchitieu> Hoadonchitieus { get; set; } = new List<Hoadonchitieu>();

    public virtual ICollection<Phieuthuhocphi> Phieuthuhocphis { get; set; } = new List<Phieuthuhocphi>();
}
