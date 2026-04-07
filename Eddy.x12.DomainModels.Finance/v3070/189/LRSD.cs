using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._189;

public class LRSD {
	[SectionPosition(1)] public RSD_ResidencyInformation ResidencyInformation { get; set; } = new();
	[SectionPosition(2)] public N4_GeographicLocation GeographicLocation { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public QTY_Quantity? Quantity { get; set; }
	[SectionPosition(5)] public REF_ReferenceIdentification? ReferenceIdentification { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRSD>(this);
		validator.Required(x => x.ResidencyInformation);
		validator.Required(x => x.GeographicLocation);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		return validator.Results;
	}
}
