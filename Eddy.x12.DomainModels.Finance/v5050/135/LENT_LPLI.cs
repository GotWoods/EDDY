using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Finance.v5050._135;

public class LENT_LPLI {
	[SectionPosition(1)] public PLI_PreviousLoanInformation PreviousLoanInformation { get; set; } = new();
	[SectionPosition(2)] public List<N1_PartyIdentification> PartyIdentification { get; set; } = new();
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT_LPLI>(this);
		validator.Required(x => x.PreviousLoanInformation);
		validator.CollectionSize(x => x.PartyIdentification, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		return validator.Results;
	}
}
