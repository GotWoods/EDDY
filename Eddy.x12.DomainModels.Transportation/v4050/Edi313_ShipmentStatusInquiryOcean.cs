using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050;

public class Edi313_ShipmentStatusInquiryOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B4_BeginningSegmentForInquiryOrReply BeginningSegmentForInquiryOrReply { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceIdentification> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<N1_Name> PartyIdentification { get; set; } = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi313_ShipmentStatusInquiryOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForInquiryOrReply);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 25);
		validator.CollectionSize(x => x.PartyIdentification, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
