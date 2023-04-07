using System;
using System.Collections.Generic;
using System.Text;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._4010._210;

    public class TransactionSet
    {
        [SectionPosition(1)]  public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; }
        [SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
        [SectionPosition(3)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
        [SectionPosition(4)] public List<H1_HazardousMaterial> HazardousMaterial { get; set; } = new();
        [SectionPosition(5)] public List<H2_AdditionalHazardousMaterialDescription> AdditionalHazardousMaterialDescription { get; set; } = new();
        [SectionPosition(6)] public List<L0_LineItemQuantityAndWeight> LineItemQuantityAndWeight { get; set; } = new();
        [SectionPosition(7)] public List<L1_RateAndCharges> RateAndCharges { get; set; } = new();
        [SectionPosition(8)] public List<L4_Measurement> Measurement { get; set; } = new();
        [SectionPosition(9)] public List<L7_TariffReference> TariffReference { get; set; } = new();
        [SectionPosition(10)] public List<K1_Remarks> Remarks { get; set; } = new();
        [SectionPosition(11)] public List<OrderDetail> OrderDetails{ get; set; } = new();
        [SectionPosition(12)] public List<PartyWithChargeDetails> Parties { get; set; } = new();
    }

