using System;
using System.Collections.Generic;

namespace QuanLyTrungTamAnhNgu.Data;

public partial class Giangvien
{
    public int Magv { get; set; }

    public string? Tengv { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Diachi { get; set; }

    public string? Gioitinh { get; set; }

    public int? Sdt { get; set; }

    public string? Socccd { get; set; }

    public string? Email { get; set; }

    public string? Trinhdo { get; set; }

    public virtual ICollection<Baikiemtra> Baikiemtras { get; set; } = new List<Baikiemtra>();

    public virtual ICollection<Baitap> Baitaps { get; set; } = new List<Baitap>();

    public virtual ICollection<Bangluong> Bangluongs { get; set; } = new List<Bangluong>();

    public virtual ICollection<Diemdanh> Diemdanhs { get; set; } = new List<Diemdanh>();

    public virtual ICollection<Lichday> Lichdays { get; set; } = new List<Lichday>();
}
