using System;
using System.Collections.Generic;

namespace QuanLyTrungTamAnhNgu.Data;

public partial class Diemdanh
{
    public int Madd { get; set; }

    public int Magv { get; set; }

    public int Mahv { get; set; }

    public string? Trangthai { get; set; }

    public DateTime? Ngayhoc { get; set; }

    public string? Cahoc { get; set; }

    public string? Ghichu { get; set; }

    public virtual Giangvien MagvNavigation { get; set; } = null!;

    public virtual Hocvien MahvNavigation { get; set; } = null!;
}
