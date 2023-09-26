using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels._8020._214;

public class Detail
{
    [SectionPosition(1)]
    public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; }

    [SectionPosition(2)]
    public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumbers { get; set; } = new();

    [SectionPosition(3)]
    public List<MAN_MarksAndNumbersInformation> MarksAndNumbers { get; set; } = new();

    [SectionPosition(4)]
    public List<Q7_LadingExceptionStatus> LadingExceptionStatus { get; set; } = new();

    [SectionPosition(5)]
    public List<K1_Remarks> Remarks { get; set; } = new();

    [SectionPosition(6)]
    public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();

    [SectionPosition(7)]
    public List<AT8_ShipmentWeightPackagingAndQuantityData> ShipmentWeightPackagingAndQuantity { get; set; } = new();

    [SectionPosition(8)]
    public List<ShipmentStatusDetails> ShipmentStatuses { get; set; } = new();


    [SectionPosition(8)]
    public List<Party> Parties { get; set; } = new();


    [SectionPosition(8)]
    public List<OrderDetail> OrderDetails { get; set; } = new();

}