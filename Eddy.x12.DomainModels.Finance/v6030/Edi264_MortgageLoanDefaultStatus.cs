using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;
using Eddy.x12.DomainModels.Finance.v6030._264;

namespace Eddy.x12.DomainModels.Finance.v6030;

public class Edi264_MortgageLoanDefaultStatus {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public MIS_MortgageeInformationStatus? MortgageeInformationStatus { get; set; }
	[SectionPosition(4)] public List<L0100> L0100 {get;set;} = new();

	//Details
	[SectionPosition(5)] public List<L0200> L0200 {get;set;} = new();

	//Summary
	[SectionPosition(6)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(7)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi264_MortgageLoanDefaultStatus>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		

		validator.CollectionSize(x => x.L0100, 1, 2);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.L0200, 1, 2147483647);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		validator.CollectionSize(x => x.QuantityInformation, 0, 2);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
