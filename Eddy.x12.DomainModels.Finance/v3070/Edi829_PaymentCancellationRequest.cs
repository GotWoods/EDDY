using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070;

public class Edi829_PaymentCancellationRequest {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public PCR_PaymentCancellationRequest PaymentCancellationRequest { get; set; } = new();
	[SectionPosition(3)] public List<TRN_Trace> Trace { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(6)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(7)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi829_PaymentCancellationRequest>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.PaymentCancellationRequest);
		validator.CollectionSize(x => x.Trace, 0, 2);
		validator.CollectionSize(x => x.DateTimeReference, 1, 10);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 10);
		validator.CollectionSize(x => x.Quantity, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
