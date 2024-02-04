using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Transportation.v7050._468;

public class L0100 {
	[SectionPosition(1)] public DK_DocketHeader DocketHeader { get; set; } = new();
	[SectionPosition(2)] public PI_PriceAuthorityIdentification? PriceAuthorityIdentification { get; set; }
	[SectionPosition(3)] public JL_JournalIdentification? JournalIdentification { get; set; }
	[SectionPosition(4)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100>(this);
		validator.Required(x => x.DocketHeader);
		validator.CollectionSize(x => x.Remarks, 0, 100);
		return validator.Results;
	}
}
