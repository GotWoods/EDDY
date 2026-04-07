using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._820;

public class L7000__L7100__L7110__L7111_L71111 {
	[SectionPosition(1)] public PCT_PercentAmounts PercentAmounts { get; set; } = new();
	[SectionPosition(2)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(3)] public List<L7000__L7100__L7110__L7111__L71111_L711111> L711111 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L7000__L7100__L7110__L7111_L71111>(this);
		validator.Required(x => x.PercentAmounts);
		validator.CollectionSize(x => x.L711111, 1, 2147483647);
		foreach (var item in L711111) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
