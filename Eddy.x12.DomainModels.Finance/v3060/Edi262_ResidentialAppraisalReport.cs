using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;
using Eddy.x12.DomainModels.Finance.v3060._262;

namespace Eddy.x12.DomainModels.Finance.v3060;

public class Edi262_ResidentialAppraisalReport {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public TRN_Trace? Trace { get; set; }
	[SectionPosition(4)] public List<LNM1> LNM1 {get;set;} = new();

	//Details
	[SectionPosition(5)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi262_ResidentialAppraisalReport>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		

		validator.CollectionSize(x => x.LNM1, 0, 5);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
