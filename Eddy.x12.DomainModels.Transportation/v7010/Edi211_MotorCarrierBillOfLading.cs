using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;
using Eddy.x12.DomainModels.Transportation.v7010._211;

namespace Eddy.x12.DomainModels.Transportation.v7010;

public class Edi211_MotorCarrierBillOfLading {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BOL_BeginningSegmentForTheMotorCarrierBillOfLading BeginningSegmentForTheMotorCarrierBillOfLading { get; set; } = new();
	[SectionPosition(3)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(4)] public List<MS3_InterlineInformation> InterlineInformation { get; set; } = new();
	[SectionPosition(5)] public MS2_EquipmentOrContainerOwnerAndType? EquipmentOrContainerOwnerAndType { get; set; }
	[SectionPosition(6)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(7)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(8)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(9)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(10)] public List<L0100> L0100 {get;set;} = new();

	//Details
	[SectionPosition(11)] public List<L0200> L0200 {get;set;} = new();
	[SectionPosition(12)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi211_MotorCarrierBillOfLading>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForTheMotorCarrierBillOfLading);
		validator.Required(x => x.SetPurpose);
		validator.CollectionSize(x => x.InterlineInformation, 0, 12);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 100);
		validator.CollectionSize(x => x.DateTime, 0, 6);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 50);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		

		validator.CollectionSize(x => x.L0100, 0, 10);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0200, 1, 9999);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
