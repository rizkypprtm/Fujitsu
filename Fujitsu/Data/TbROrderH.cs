using System;
using System.Collections.Generic;

namespace Fujitsu.Data;

public partial class TbROrderH
{
    public string OrderNo { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string SupplierCode { get; set; }

    public decimal? Amount { get; set; }
}
