﻿using System;
using System.Collections.Generic;

namespace QuanLyTrungTamAnhNgu.Data;

public partial class Phieulapdat
{
    public int Sophieu { get; set; }

    public int Mahd { get; set; }

    public int? Soluong { get; set; }

    public decimal? Thanhtien { get; set; }

    public string? Noidung { get; set; }

    public virtual ICollection<CtLapdat> CtLapdats { get; set; } = new List<CtLapdat>();

    public virtual Hoadonchitieu MahdNavigation { get; set; } = null!;
}
