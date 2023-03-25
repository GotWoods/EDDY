﻿using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.DomainModels._210;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._204
{
    
    public class StopOffDetails
    {
        [SectionPosition(1)]
        public S5_StopOffDetails Detail { get; set; }

        [SectionPosition(2)]
        public List<L11_BusinessInstructionsAndReferenceNumber> ReferenceNumbers { get; set; } = new();

        [SectionPosition(3)]
        public List<G62_DateTime> Dates { get; set; } = new();

        [SectionPosition(4)]
        public AT8_ShipmentWeightPackagingAndQuantityData ShipmentWeightPackagingAndQuantityData { get; set; }

        [SectionPosition(5)]
        public LAD_LadingDetail LadingDetail { get; set; }

        [SectionPosition(6)]
        public List<BillOfLadingHandlingInfo> BillOfLadingHandlingRequirements { get; set; } = new();

        [SectionPosition(7)]
        public PLD_PalletShipmentInformation PalletInformation { get; set; }

        [SectionPosition(8)]
        public List<NTE_Note> Notes { get; set; } = new();
        
        [SectionPosition(9)] //SpecialMap
        public Entity Entity {  get; set; }

        //[SectionPosition(10)] /*0320 L5, AT8*/
        [SectionPosition(11)]
        public List<ShipmentInformationDetail> ShipmentDetails { get; set; } = new();


        [SectionPosition(11)] /*OID, G62, LAD*/
        public List<OrderInformationDetail2> Details { get; set; } = new();

        
        [SectionPosition(12)]
        public List<EquipmentDetails> EquipmentDetails { get; set; } = new();
        //details

    }
}
