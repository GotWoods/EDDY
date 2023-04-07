using System;
using System.Collections.Generic;
using System.Linq;
using EdiParser.Attributes;
using EdiParser.x12.DomainModels._8020._210;
using EdiParser.x12.Internals;
using EdiParser.x12.Internals.Beta;
using EdiParser.x12.Models;
using static System.String;

namespace EdiParser.x12.DomainModels;

public class Edi210_MotorCarrierFreightDetailsAndInvoice
{
    //Header
    [SectionPosition(1)] public B3_BeginningSegmentForCarriersInvoice Details { get; set; } = new();
    [SectionPosition(2)] public C2_BankID BankIdentification { get; set; }
    [SectionPosition(3)] public C3_CurrencyIdentifier Currency { get; set; }
    [SectionPosition(4)] public ITD_TermsOfSaleDeferredTermsOfSale TermsOfSale { get; set; }
    [SectionPosition(5)] public List<L11_BusinessInstructionsAndReferenceNumber> InstructionsAndReferenceNumbers { get; set; } = new();
    [SectionPosition(6)] public List<G62_DateTime> DateTime { get; set; } = new();
    [SectionPosition(7)] public List<R3_RouteInformationMotor> RouteInformation { get; set; } = new();
    [SectionPosition(8)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
    [SectionPosition(9)] public List<K1_Remarks> Remarks { get; set; } = new();
    [SectionPosition(10)] public List<Party> Parties { get; set; } = new();
    [SectionPosition(11)] public List<EquipmentDetails> EquipmentDetails { get; set; } = new();
    [SectionPosition(12)] public List<OrderDetail> OrderDetails{ get; set; } = new();

    //Detail
    [SectionPosition(13)] public List<StopOffDetails> Stops { get; set; } = new();
}