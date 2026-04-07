using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._176;

public class LFGS_LEFI {
	[SectionPosition(1)] public EFI_ElectronicFormatIdentification ElectronicFormatIdentification { get; set; } = new();
	[SectionPosition(2)] public BIN_BinaryDataSegment BinaryDataSegment { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LFGS_LEFI>(this);
		validator.Required(x => x.ElectronicFormatIdentification);
		validator.Required(x => x.BinaryDataSegment);
		return validator.Results;
	}
}
