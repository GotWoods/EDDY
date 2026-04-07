using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;
using Eddy.x12.DomainModels.Finance.v5050._149;

namespace Eddy.x12.DomainModels.Finance.v5050;

public class Edi149_NoticeOfTaxAdjustmentOrAssessment {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public TDS_TotalMonetaryValueSummary? TotalMonetaryValueSummary { get; set; }
	[SectionPosition(5)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(7)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(8)] public List<LTFS> LTFS {get;set;} = new();
	[SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi149_NoticeOfTaxAdjustmentOrAssessment>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		

		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LTFS, 1, 2147483647);
		foreach (var item in LTFS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
