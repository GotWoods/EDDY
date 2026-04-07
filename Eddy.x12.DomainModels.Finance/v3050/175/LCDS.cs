using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._175;

public class LCDS {
	[SectionPosition(1)] public CDS_CaseDescription CaseDescription { get; set; } = new();
	[SectionPosition(2)] public SPI_SpecificationIdentifier? SpecificationIdentifier { get; set; }
	[SectionPosition(3)] public LS_LoopHeader LoopHeader { get; set; } = new();
	[SectionPosition(4)] public List<LCDS_LCED> LCED {get;set;} = new();
	[SectionPosition(5)] public LE_LoopTrailer LoopTrailer { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCDS>(this);
		validator.Required(x => x.CaseDescription);
		validator.Required(x => x.LoopHeader);
		validator.Required(x => x.LoopTrailer);
		validator.CollectionSize(x => x.LCED, 1, 2147483647);
		foreach (var item in LCED) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
