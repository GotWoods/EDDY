using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Transportation.v6040._204;

public class L0300_L0350 {
	[SectionPosition(1)] public OID_OrderInformationDetail OrderInformationDetail { get; set; } = new();
	[SectionPosition(2)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(3)] public List<LAD_LadingDetail> LadingDetail { get; set; } = new();
	[SectionPosition(4)] public List<L0300__L0350_L0360> L0360 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300_L0350>(this);
		validator.Required(x => x.OrderInformationDetail);
		validator.CollectionSize(x => x.DateTime, 0, 2);
		validator.CollectionSize(x => x.LadingDetail, 0, 99999);
		validator.CollectionSize(x => x.L0360, 0, 99999);
		foreach (var item in L0360) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
