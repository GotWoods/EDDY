using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.DomainModels._204;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._8020._210
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
        public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();

        [SectionPosition(5)]
        public List<OrderDetail> OrderDetail { get; set; } = new();

        [SectionPosition(6)]
        public List<PartyWithEquipmentDetails> Parties { get; set; } = new();
    }
}
