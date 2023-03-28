using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._4010._214
{
    public class Detail
    {
        [SectionPosition(1)]
        public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; }

        [SectionPosition(2)]
        public List<ShipmentStatusDetails> ShipmentStatusDetails { get; set; } = new();

       
        [SectionPosition(3)]
        public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumbers { get; set; } = new();

        [SectionPosition(4)]
        public List<MAN_MarksAndNumbersInformation> MarksAndNumbers { get; set; } = new();

        [SectionPosition(5)]
        public List<Q7_LadingExceptionStatus> LadingExceptionStatus { get; set; } = new();

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
