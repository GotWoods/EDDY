using Eddy.Core.Attributes;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels._8020._204;

public class BillOfLadingHandlingInfo
{
    [SectionPosition(1)]
    public AT5_BillOfLadingHandlingRequirements HandlingRequirements { get; set; }
    [SectionPosition(2)]
    public RTT_FreightRateInformation FreightRateInformation { get; set; }
    [SectionPosition(3)]
    public C3_CurrencyIdentifier Currency { get; set; }
}