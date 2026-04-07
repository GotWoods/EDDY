using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;
using Eddy.x12.DomainModels.Finance.v4050._203;

namespace Eddy.x12.DomainModels.Finance.v4050;

public class Edi203_SecondaryMortgageMarketInvestorReport {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public DTP_DateOrTimeOrPeriod DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public REF_ReferenceIdentification ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(6)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi203_SecondaryMortgageMarketInvestorReport>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.DateOrTimeOrPeriod);
		validator.Required(x => x.ReferenceInformation);
		

		validator.CollectionSize(x => x.LN1, 0, 5);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
