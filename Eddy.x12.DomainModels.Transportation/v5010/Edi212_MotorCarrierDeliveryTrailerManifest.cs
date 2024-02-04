using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;
using Eddy.x12.DomainModels.Transportation.v5010._212;

namespace Eddy.x12.DomainModels.Transportation.v5010;

public class Edi212_MotorCarrierDeliveryTrailerManifest {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest BeginningSegmentForMotorCarrierDeliveryTrailerManifest { get; set; } = new();
	[SectionPosition(3)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(4)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(5)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(6)] public List<L0150> L0150 {get;set;} = new();

	//Details
	[SectionPosition(7)] public List<L0200> L0200 {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi212_MotorCarrierDeliveryTrailerManifest>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForMotorCarrierDeliveryTrailerManifest);
		validator.Required(x => x.SetPurpose);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 300);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0150) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0200, 0, 9999);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
