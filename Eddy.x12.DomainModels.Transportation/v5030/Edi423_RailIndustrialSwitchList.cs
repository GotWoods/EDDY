using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;
using Eddy.x12.DomainModels.Transportation.v5030._423;

namespace Eddy.x12.DomainModels.Transportation.v5030;

public class Edi423_RailIndustrialSwitchList {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public LQ_IndustryCodeIdentification? IndustryCodeIdentification { get; set; }
	[SectionPosition(5)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(6)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(7)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi423_RailIndustrialSwitchList>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateTimeReference, 0, 3);
		validator.CollectionSize(x => x.QuantityInformation, 0, 3);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 1, 5);
		validator.CollectionSize(x => x.LLX, 0, 150);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
