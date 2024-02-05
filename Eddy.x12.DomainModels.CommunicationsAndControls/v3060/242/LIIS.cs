using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v3060._242;

public class LIIS {
	[SectionPosition(1)] public IIS_InterchangeIdentificationSegment InterchangeIdentificationSegment { get; set; } = new();
	[SectionPosition(2)] public List<LIIS_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIIS>(this);
		validator.Required(x => x.InterchangeIdentificationSegment);
		validator.CollectionSize(x => x.LN1, 1, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
