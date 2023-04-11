﻿using System.Collections.Generic;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels._8020._210;

public class OrderDetail
{
    public OID_OrderInformationDetail Detail { get; set; }
    public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
}