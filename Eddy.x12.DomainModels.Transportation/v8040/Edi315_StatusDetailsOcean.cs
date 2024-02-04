using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;
using Eddy.x12.DomainModels.Transportation.v8040._315;

namespace Eddy.x12.DomainModels.Transportation.v8040;

public class Edi315_StatusDetailsOcean {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B4_BeginningSegmentForInquiryOrReply BeginningSegmentForInquiryOrReply { get; set; } = new();
	[SectionPosition(3)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public Q2_StatusDetailsOcean? StatusDetailsOcean { get; set; }
	[SectionPosition(5)] public List<SG_ShipmentStatus> ShipmentStatus { get; set; } = new();
	[SectionPosition(6)] public List<LR4> LR4 {get;set;} = new();
	[SectionPosition(7)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi315_StatusDetailsOcean>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForInquiryOrReply);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 30);
		validator.CollectionSize(x => x.ShipmentStatus, 0, 15);
		validator.CollectionSize(x => x.EventDetail, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LR4, 1, 20);
		foreach (var item in LR4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
