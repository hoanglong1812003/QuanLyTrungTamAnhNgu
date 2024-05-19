using System;
using System.Collections.Generic;

namespace QuanLyTrungTamAnhNgu.Data;

public partial class Hocvien
{
    public int Mahv { get; set; }

    public string? Tenhv { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Gioitinh { get; set; }

    public string? Diachi { get; set; }

    public string? Socccd { get; set; }

    public int? Sdt { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Baikiemtra> Baikiemtras { get; set; } = new List<Baikiemtra>();

    public virtual ICollection<Baitap> Baitaps { get; set; } = new List<Baitap>();

    public virtual ICollection<Diemdanh> Diemdanhs { get; set; } = new List<Diemdanh>();

    public virtual ICollection<Lichhoc> Lichhocs { get; set; } = new List<Lichhoc>();

    public virtual ICollection<Phieuthuhocphi> Phieuthuhocphis { get; set; } = new List<Phieuthuhocphi>();
}
