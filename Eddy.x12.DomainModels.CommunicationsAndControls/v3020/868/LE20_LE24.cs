using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3020._868;

public class LE20_LE24 {
	[SectionPosition(1)] public E24_DataElementSequenceInASegment DataElementSequenceInASegment { get; set; } = new();
	[SectionPosition(2)] public List<E26_ElementSequenceInComposite> ElementSequenceInComposite { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE20_LE24>(this);
		validator.Required(x => x.DataElementSequenceInASegment);
		validator.CollectionSize(x => x.ElementSequenceInComposite, 0, 100);
		return validator.Results;
	}
}
