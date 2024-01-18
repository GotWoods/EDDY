using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060._204;

public class L0300_L0350 {
	[SectionPosition(1)] public OID_OrderInformationDetail OrderInformationDetail { get; set; } = new();
	[SectionPosition(2)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(3)] public List<LAD_LadingDetail> LadingDetail { get; set; } = new();
	[SectionPosition(4)] public List<L0300__L0350_L0360> L0360 {get;set;} = new();
}
