using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Finance.v7050._189;

public class LRSD {
	[SectionPosition(1)] public RSD_ResidencyInformation ResidencyInformation { get; set; } = new();
	[SectionPosition(2)] public N4_GeographicLocation GeographicLocation { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(5)] public REF_ReferenceInformation? ReferenceInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRSD>(this);
		validator.Required(x => x.ResidencyInformation);
		validator.Required(x => x.GeographicLocation);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		return validator.Results;
	}
}
