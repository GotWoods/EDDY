using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;
using Eddy.x12.DomainModels.Transportation.v3040._926;

namespace Eddy.x12.DomainModels.Transportation.v3040;

public class Edi926_ClaimStatusReportAndTracerReply {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<LF11> LF11 {get;set;} = new();
	[SectionPosition(3)] public F13_PaymentInformation? PaymentInformation { get; set; }
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi926_ClaimStatusReportAndTracerReply>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LF11, 1, 500);
		foreach (var item in LF11) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
