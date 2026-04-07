using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Finance.v7050._189;

public class LIN1_LN1 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(5)] public List<LIN1__LN1_LEMS> LEMS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1_LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.LEMS, 0, 5);
		foreach (var item in LEMS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
