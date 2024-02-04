using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;
using Eddy.x12.DomainModels.Transportation.v6040._204;

namespace Eddy.x12.DomainModels.Transportation.v6040;

public class Edi204_MotorCarrierLoadTender {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B2_BeginningSegmentForShipmentInformationTransaction BeginningSegmentForShipmentInformationTransaction { get; set; } = new();
	[SectionPosition(3)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(4)] public C3_CurrencyIdentifier? CurrencyIdentifier { get; set; }
	[SectionPosition(5)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public G62_DateTime? DateTime { get; set; }
	[SectionPosition(7)] public MS3_InterlineInformation? InterlineInformation { get; set; }
	[SectionPosition(8)] public List<L0050> L0050 {get;set;} = new();
	[SectionPosition(9)] public PLD_PalletShipmentInformation? PalletShipmentInformation { get; set; }
	[SectionPosition(10)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(11)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(12)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(13)] public List<L0200> L0200 {get;set;} = new();

	//Details
	[SectionPosition(14)] public List<L0300> L0300 {get;set;} = new();

	//Summary
	[SectionPosition(15)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(16)] public List<L1000> L1000 {get;set;} = new();
	[SectionPosition(17)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi204_MotorCarrierLoadTender>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShipmentInformationTransaction);
		validator.Required(x => x.SetPurpose);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 99999);
		validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		

		validator.CollectionSize(x => x.L0050, 0, 99);
		validator.CollectionSize(x => x.L0100, 0, 5);
		validator.CollectionSize(x => x.L0200, 0, 10);
		foreach (var item in L0050) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.L0300, 1, 999);
		foreach (var item in L0300) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		foreach (var item in L1000) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
