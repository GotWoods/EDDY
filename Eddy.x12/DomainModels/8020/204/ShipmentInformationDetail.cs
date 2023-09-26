using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels._8020._204;

public class ShipmentInformationDetail
{
    [SectionPosition(1)]
    public L5_DescriptionMarksAndNumbers DescriptionMarksAndNumbers { get; set; }
    [SectionPosition(2)]
    public AT8_ShipmentWeightPackagingAndQuantityData ShipmentWeightPackagingQuantity { get; set; }

    [SectionPosition(3)]
    public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();

    [SectionPosition(4)]
    public List<L11_BusinessInstructionsAndReferenceNumber> ReferenceNumbers { get; set; } = new();

    [SectionPosition(5)]
    public List<MEA_Measurements> Measurements { get; set; } = new();

    [SectionPosition(6)]
    public PER_AdministrativeCommunicationsContact AdministrativeCommunicationsContact { get; set; }

    [SectionPosition(7)]
    public L4_Measurement Measurement { get; set; }

    [SectionPosition(8)]
    public List<ShipmentDetailContact> Detail { get; set; } = new();
}