using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Finance.v6040._158;

public class LDTP_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(3)] public PPA_PropertyLocation? PropertyLocation { get; set; }
	[SectionPosition(4)] public List<TA_TaxAuthority> TaxAuthority { get; set; } = new();
	[SectionPosition(5)] public ASI_ActionOrStatusIndicator? ActionOrStatusIndicator { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDTP_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.LocationIDComponent, 1, 2147483647);
		validator.CollectionSize(x => x.TaxAuthority, 1, 2147483647);
		return validator.Results;
	}
}
