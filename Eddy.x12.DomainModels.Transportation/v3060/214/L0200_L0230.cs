using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._214;

public class L0200_L0230 {
	[SectionPosition(1)] public PRF_PurchaseOrderReference PurchaseOrderReference { get; set; } = new();
	[SectionPosition(2)] public List<L0200__L0230_L0231> L0231 {get;set;} = new();
	[SectionPosition(3)] public List<L0200__L0230_L0233> L0233 {get;set;} = new();
}
