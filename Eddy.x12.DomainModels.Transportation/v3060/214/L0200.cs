using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._214;

public class L0200 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<Q5_StatusDetails> StatusDetails { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(4)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(5)] public List<Q7_LadingExceptionCode> LadingExceptionCode { get; set; } = new();
	[SectionPosition(6)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(7)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(8)] public G86_Signature? Signature { get; set; }
	[SectionPosition(9)] public List<Q6_ShipmentDetails> ShipmentDetails { get; set; } = new();
	[SectionPosition(10)] public List<L0200_L0210> L0210 {get;set;} = new();
	[SectionPosition(11)] public List<L0200_L0230> L0230 {get;set;} = new();
	[SectionPosition(12)] public List<L0200_L0250> L0250 {get;set;} = new();
}
