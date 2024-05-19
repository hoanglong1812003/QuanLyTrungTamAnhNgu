using System;
using System.Collections.Generic;

namespace QuanLyTrungTamAnhNgu.Data;

public partial class CtLapdat
{
    public int Matb { get; set; }

    public int Sophieu { get; set; }

    public DateTime Ngaylapdat { get; set; }

    public string Ghichu { get; set; } = null!;

    public virtual Thietbi MatbNavigation { get; set; } = null!;

    public virtual Phieulapdat SophieuNavigation { get; set; } = null!;
}
