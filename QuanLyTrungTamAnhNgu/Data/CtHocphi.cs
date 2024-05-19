﻿using System;
using System.Collections.Generic;

namespace QuanLyTrungTamAnhNgu.Data;

public partial class CtHocphi
{
    public int Makh { get; set; }

    public int Maphieu { get; set; }

    public string Mota { get; set; } = null!;

    public virtual Khoahoc MakhNavigation { get; set; } = null!;

    public virtual Phieuthuhocphi MaphieuNavigation { get; set; } = null!;
}
