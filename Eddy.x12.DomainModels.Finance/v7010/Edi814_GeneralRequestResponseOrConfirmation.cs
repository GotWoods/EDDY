using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;
using Eddy.x12.DomainModels.Finance.v7010._814;

namespace Eddy.x12.DomainModels.Finance.v7010;

public class Edi814_GeneralRequestResponseOrConfirmation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public LCD_PlaceLocationDescription? PlaceLocationDescription { get; set; }
	[SectionPosition(6)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(7)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(8)] public List<MTX_Text> Text { get; set; } = new();
	[SectionPosition(9)] public List<LFA1> LFA1 {get;set;} = new();
	[SectionPosition(10)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(11)] public List<LLM> LLM {get;set;} = new();

	//Details
	[SectionPosition(12)] public List<LLIN> LLIN {get;set;} = new();

	//Summary
	[SectionPosition(13)] public List<LAWD> LAWD {get;set;} = new();
	[SectionPosition(14)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi814_GeneralRequestResponseOrConfirmation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		

		validator.CollectionSize(x => x.LFA1, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		foreach (var item in LFA1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LLIN, 1, 2147483647);
		foreach (var item in LLIN) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LAWD, 1, 2147483647);
		foreach (var item in LAWD) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
