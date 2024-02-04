using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;
using Eddy.x12.DomainModels.Transportation.v6020._456;

namespace Eddy.x12.DomainModels.Transportation.v6020;

public class Edi456_RailroadEquipmentInquiryOrAdvice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public EIA_BeginningSegmentForEquipmentInquiryOrAdvice BeginningSegmentForEquipmentInquiryOrAdvice { get; set; } = new();
	[SectionPosition(3)] public List<N8_WaybillReference> WaybillReference { get; set; } = new();
	[SectionPosition(4)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(5)] public List<LIS1> LIS1 {get;set;} = new();
	[SectionPosition(6)] public List<LER> LER {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi456_RailroadEquipmentInquiryOrAdvice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForEquipmentInquiryOrAdvice);
		validator.CollectionSize(x => x.WaybillReference, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLX, 0, 500);
		validator.CollectionSize(x => x.LER, 0, 99);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIS1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LER) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
