using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._204;

public class L0300 {
	[SectionPosition(1)] public S5_StopOffDetails StopOffDetails { get; set; } = new();
	[SectionPosition(2)] public List<LAD_LadingDetail> LadingDetail { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(4)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(5)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(6)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(7)] public List<H6_SpecialServices> SpecialServices { get; set; } = new();
	[SectionPosition(8)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(9)] public List<L0300_L0305> L0305 {get;set;} = new();
	[SectionPosition(10)] public List<L0300_L0310> L0310 {get;set;} = new();
}
