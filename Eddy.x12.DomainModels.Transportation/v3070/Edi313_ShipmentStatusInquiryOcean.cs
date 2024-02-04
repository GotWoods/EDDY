using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;
using Eddy.x12.DomainModels.Transportation.v3070._313;

namespace Eddy.x12.DomainModels.Transportation.v3070;

public class Edi313_ShipmentStatusInquiryOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B4_BeginningSegmentForInquiryOrReply BeginningSegmentForInquiryOrReply { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(4)] public List<N1_Name> Name { get; set; } = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi313_ShipmentStatusInquiryOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForInquiryOrReply);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 25);
		validator.CollectionSize(x => x.Name, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
