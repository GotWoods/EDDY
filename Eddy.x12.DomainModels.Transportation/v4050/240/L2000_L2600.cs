using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._240;

public class L2000_L2600 {
	[SectionPosition(1)] public EFI_ElectronicFormatIdentification ElectronicFormatIdentification { get; set; } = new();
	[SectionPosition(2)] public BIN_BinaryData BinaryDataSegment { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2600>(this);
		validator.Required(x => x.ElectronicFormatIdentification);
		validator.Required(x => x.BinaryDataSegment);
		return validator.Results;
	}
}