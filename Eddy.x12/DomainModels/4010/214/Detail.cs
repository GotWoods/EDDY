using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;
using MAN_MarksAndNumbers = Eddy.x12.Models.v3020.MAN_MarksAndNumbers;

namespace Eddy.x12.DomainModels._4010._214
{
    public class Detail
    {
        [SectionPosition(1)]
        public LX_AssignedNumber TransactionSetLineNumber { get; set; }

        [SectionPosition(2)]
        public List<ShipmentStatusDetails> ShipmentStatusDetails { get; set; } = new();

       
        [SectionPosition(3)]
        public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumbers { get; set; } = new();

        [SectionPosition(4)]
        public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();

        [SectionPosition(5)]
        public List<Q7_LadingExceptionCode> LadingExceptionStatus { get; set; } = new();

        [SectionPosition(6)]
        public List<K1_Remarks> Remarks { get; set; } = new();

        [SectionPosition(7)]
        public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();

        [SectionPosition(8)]
        public List<AT8_ShipmentWeightPackagingAndQuantityData> ShipmentWeightPackagingAndQuantity { get; set; } = new();

        [SectionPosition(9)]
        public List<CartonDetail> CartonDetails { get; set; } = new();

        [SectionPosition(10)]
        public List<PurchaseOrderReference> PurchaseOrderReferences { get; set; } = new();

        [SectionPosition(11)]
        public List<PurchaseOrderDetails> PurchaseOrderDetails { get; set; } = new();
        // public List<ShipmentStatusDetails> ShipmentStatuses { get; set; } = new();
        //
        //
        // [SectionPosition(8)]
        // public List<Parties> Parties { get; set; } = new();
        //
        //
        // [SectionPosition(8)]
        // public List<OrderDetail> OrderDetails { get; set; } = new();

    }
}
