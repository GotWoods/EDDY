using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;
using Eddy.x12.DomainModels.Transportation.v3050._456;

namespace Eddy.x12.DomainModels.Transportation.v3050;

public class Edi456_RailroadEquipmentInquiryOrAdvice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public EIA_BeginningSegmentForEquipmentInquiryOrAdvice BeginningSegmentForEquipmentInquiryOrAdvice { get; set; } = new();
	[SectionPosition(3)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi456_RailroadEquipmentInquiryOrAdvice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForEquipmentInquiryOrAdvice);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLX, 0, 99);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
