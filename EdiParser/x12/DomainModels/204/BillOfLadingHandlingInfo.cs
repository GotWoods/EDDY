using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._204;

public class BillOfLadingHandlingInfo
{
    public AT5_BillOfLadingHandlingRequirements HandlingRequirements { get; set; }
    public RTT_FreightRateInformation FreightRateInformation { get; set; }
    public C3_CurrencyIdentifier Currency { get; set; }
}