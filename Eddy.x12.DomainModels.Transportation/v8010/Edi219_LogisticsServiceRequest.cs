using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;
using Eddy.x12.DomainModels.Transportation.v8010._219;

namespace Eddy.x12.DomainModels.Transportation.v8010;

public class Edi219_LogisticsServiceRequest {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B9_BeginningSegmentForLogisticsServices BeginningSegmentForLogisticsServices { get; set; } = new();
	[SectionPosition(3)] public List<B9A_ServiceRequest> ServiceRequest { get; set; } = new();
	[SectionPosition(4)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(5)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public List<MS3_InterlineInformation> InterlineInformation { get; set; } = new();
	[SectionPosition(7)] public List<ITA_AllowanceChargeOrService> AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(8)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(9)] public List<L1000> L1000 {get;set;} = new();

	//Details
	[SectionPosition(10)] public List<L2000> L2000 {get;set;} = new();

	//Summary
	[SectionPosition(11)] public L3_TotalWeightAndCharges TotalWeightAndCharges { get; set; } = new();
	[SectionPosition(12)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi219_LogisticsServiceRequest>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForLogisticsServices);
		validator.CollectionSize(x => x.ServiceRequest, 1, 7);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 6);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 1, 2147483647);
		validator.CollectionSize(x => x.InterlineInformation, 0, 99);
		validator.CollectionSize(x => x.AllowanceChargeOrService, 0, 20);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		

		validator.CollectionSize(x => x.L1000, 0, 99);
		foreach (var item in L1000) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.L2000, 0, 99);
		foreach (var item in L2000) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TotalWeightAndCharges);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
