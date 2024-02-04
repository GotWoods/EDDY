using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;
using Eddy.x12.DomainModels.Transportation.v4060._220;

namespace Eddy.x12.DomainModels.Transportation.v4060;

public class Edi220_LogisticsServiceResponse {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B9_BeginningSegmentForLogisticsServices BeginningSegmentForLogisticsServices { get; set; } = new();
	[SectionPosition(3)] public List<B9A_ServiceRequest> ServiceRequest { get; set; } = new();
	[SectionPosition(4)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(5)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(6)] public List<MS3_InterlineInformation> InterlineInformation { get; set; } = new();
	[SectionPosition(7)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(8)] public List<L0500> L0500 {get;set;} = new();
	[SectionPosition(9)] public List<L1000> L1000 {get;set;} = new();

	//Details
	[SectionPosition(10)] public List<L2000> L2000 {get;set;} = new();
	[SectionPosition(11)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi220_LogisticsServiceResponse>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForLogisticsServices);
		validator.CollectionSize(x => x.ServiceRequest, 0, 7);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 1, 2147483647);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		validator.CollectionSize(x => x.InterlineInformation, 0, 99);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		

		validator.CollectionSize(x => x.L0500, 0, 99);
		validator.CollectionSize(x => x.L1000, 0, 99);
		foreach (var item in L0500) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L1000) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L2000, 0, 99);
		foreach (var item in L2000) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
