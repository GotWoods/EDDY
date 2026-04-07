using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._820;

public class L7000__L7100__L7110_L7111 {
	[SectionPosition(1)] public PID_ProductItemDescription ProductItemDescription { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(3)] public List<L7000__L7100__L7110__L7111_L71111> L71111 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L7000__L7100__L7110_L7111>(this);
		validator.Required(x => x.ProductItemDescription);
		validator.CollectionSize(x => x.L71111, 1, 2147483647);
		foreach (var item in L71111) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
