using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels._4010._210;

public class Charges
{
    [SectionPosition(1)] public CD3_CartonPackageDetail Details{ get; set; }
    [SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> ReferenceNumbers { get; set; }
    [SectionPosition(3)] public List<H6_SpecialServices> SpecialServices{ get; set; } = new();
    [SectionPosition(4)] public List<L9_ChargeDetail> ChargeDetails{ get; set; } = new();
    [SectionPosition(5)] public POD_ProofOfDelivery ProofOfDelivery { get; set; }
    [SectionPosition(6)] public G62_DateTime DateTime { get; set; }


}