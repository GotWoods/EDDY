using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v4040._868;

public class LE30_LE34 {
	[SectionPosition(1)] public E34_CodeListValuesForADataElement CodeListValuesForADataElement { get; set; } = new();
	[SectionPosition(2)] public List<DDI_Description> Description { get; set; } = new();
	[SectionPosition(3)] public List<DAI_AppendixInformation> AppendixInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE30_LE34>(this);
		validator.Required(x => x.CodeListValuesForADataElement);
		validator.CollectionSize(x => x.Description, 0, 20);
		validator.CollectionSize(x => x.AppendixInformation, 0, 5);
		return validator.Results;
	}
}
