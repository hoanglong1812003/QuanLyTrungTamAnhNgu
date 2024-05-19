﻿using System;
using System.Collections.Generic;

namespace QuanLyTrungTamAnhNgu.Data;

public partial class Lichhoc
{
    public int Malh { get; set; }

    public int Mahv { get; set; }

    public int Malop { get; set; }

    public string? Tuan { get; set; }

    public string? Cahoc { get; set; }

    public DateTime? Ngayhoc { get; set; }

    public string? Ghichu { get; set; }

    public virtual Hocvien MahvNavigation { get; set; } = null!;

    public virtual Lophoc MalopNavigation { get; set; } = null!;
}
