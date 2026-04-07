using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._280;

public class LPWK_LEFI {
	[SectionPosition(1)] public EFI_ElectronicFormatIdentification ElectronicFormatIdentification { get; set; } = new();
	[SectionPosition(2)] public BIN_BinaryData? BinaryData { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPWK_LEFI>(this);
		validator.Required(x => x.ElectronicFormatIdentification);
		return validator.Results;
	}
}
