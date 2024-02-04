using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;
using Eddy.x12.DomainModels.Transportation.v5030._311;

namespace Eddy.x12.DomainModels.Transportation.v5030;

public class Edi311_CanadaCustomsInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(3)] public List<Y6_Authentication> Authentication { get; set; } = new();
	[SectionPosition(4)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public V1_VesselIdentification? VesselIdentification { get; set; }
	[SectionPosition(6)] public V2_VesselInformation? VesselInformation { get; set; }
	[SectionPosition(7)] public V3_VesselSchedule? VesselSchedule { get; set; }
	[SectionPosition(8)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(9)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(10)] public List<R4_PortOrTerminal> PortOrTerminal { get; set; } = new();
	[SectionPosition(11)] public List<K1_Remarks> HeaderRemarks { get; set; } = new();

	//Details
	[SectionPosition(12)] public List<LLX> LLX {get;set;} = new();

	//Summary
	[SectionPosition(13)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(14)] public List<K1_Remarks> SummaryRemarks { get; set; } = new();
	[SectionPosition(15)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi311_CanadaCustomsInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.SetPurpose);
		validator.CollectionSize(x => x.Authentication, 0, 2);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 10);
		validator.CollectionSize(x => x.DateTimeReference, 0, 2);
		validator.CollectionSize(x => x.PortOrTerminal, 1, 10);
		validator.CollectionSize(x => x.HeaderRemarks, 0, 5);
		

		validator.CollectionSize(x => x.LN1, 1, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LLX, 1, 999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.CollectionSize(x => x.SummaryRemarks, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
