using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._204;

public class BillOfLadingHandlingInfo
{
    [SectionPosition(1)]
    public AT5_BillOfLadingHandlingRequirements HandlingRequirements { get; set; }
    [SectionPosition(2)]
    public RTT_FreightRateInformation FreightRateInformation { get; set; }
    [SectionPosition(3)]
    public C3_CurrencyIdentifier Currency { get; set; }
}