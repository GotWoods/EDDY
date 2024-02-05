using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;
using Eddy.x12.DomainModels.CommunicationsAndControls.v7010._864;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v7010;

public class Edi864_TextMessage {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BMG_BeginningSegmentForTextMessage BeginningSegmentForTextMessage { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(5)] public List<LMIT> LMIT {get;set;} = new();

	//Summary
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi864_TextMessage>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForTextMessage);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		

		validator.CollectionSize(x => x.LN1, 0, 200);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LMIT, 1, 2147483647);
		foreach (var item in LMIT) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
