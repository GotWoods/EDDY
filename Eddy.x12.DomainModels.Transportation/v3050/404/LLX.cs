using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._404;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(3)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(4)] public List<LLX_LLX> LLX {get;set;} = new();
	[SectionPosition(5)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(6)] public List<PI_PriceAuthorityIdentification> PriceAuthorityIdentification { get; set; } = new();
	[SectionPosition(7)] public List<X1_ExportLicense> ExportLicense { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 1, 15);
		validator.CollectionSize(x => x.PriceAuthorityIdentification, 0, 30);
		validator.CollectionSize(x => x.ExportLicense, 0, 6);
		validator.CollectionSize(x => x.LLX, 0, 25);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
