using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._214;

public class L0200__L0230_L0233 {
	[SectionPosition(1)] public CD3_CartonPackageDetail CartonPackageDetail { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<Q5_StatusDetails> StatusDetails { get; set; } = new();
	[SectionPosition(4)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200__L0230_L0233>(this);
		validator.Required(x => x.CartonPackageDetail);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 20);
		validator.CollectionSize(x => x.StatusDetails, 0, 10);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 9999);
		return validator.Results;
	}
}
