using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._211
{
    public class BillOfLadingLine
    {
        [SectionPosition(1)] public AT1_BillOfLadingLineItemNumber BillOfLadingLineItemNumber { get; set; }
        [SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumbers { get; set; } = new();
        [SectionPosition(3)] public AT3_BillOfLadingRatesAndCharges RatesAndCharges { get; set; }
        [SectionPosition(4)] public List<AT4_BillOfLadingDescription> Description { get; set; } = new();
        [SectionPosition(5)] public LineDetail LineDetail { get; set; }
        [SectionPosition(6)] public List<Numbers> Numbers { get; set; } = new();
        [SectionPosition(7)] public List<HazMatContact> HazMatContacts{ get; set; } = new();

    }
}
