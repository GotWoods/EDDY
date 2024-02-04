using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._214;

public class L0200_L0260 {
	[SectionPosition(1)] public EFI_ElectronicFormatIdentification ElectronicFormatIdentification { get; set; } = new();
	[SectionPosition(2)] public BIN_BinaryData BinaryData { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0260>(this);
		validator.Required(x => x.ElectronicFormatIdentification);
		validator.Required(x => x.BinaryData);
		return validator.Results;
	}
}
