using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Transportation.v5030._215;

public class L0200 {
	[SectionPosition(1)] public SMD_ConsolidatedShipmentManifestData ConsolidatedShipmentManifestData { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(4)] public List<MS6_ShipmentQuantityAndWeight> ShipmentQuantityAndWeight { get; set; } = new();
	[SectionPosition(5)] public List<MS5_ShipmentRatesAndCharges> ShipmentRatesAndCharges { get; set; } = new();
	[SectionPosition(6)] public MS4_ShipmentOrPackageDimensions? ShipmentOrPackageDimensions { get; set; }
	[SectionPosition(7)] public List<ACS_AncillaryCharges> AncillaryCharges { get; set; } = new();
	[SectionPosition(8)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(9)] public List<L0200_L0220> L0220 {get;set;} = new();
	[SectionPosition(10)] public List<L0200_L0240> L0240 {get;set;} = new();
	[SectionPosition(11)] public List<L0200_L0260> L0260 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.ConsolidatedShipmentManifestData);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 20);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 10);
		validator.CollectionSize(x => x.ShipmentQuantityAndWeight, 0, 10);
		validator.CollectionSize(x => x.ShipmentRatesAndCharges, 0, 5);
		validator.CollectionSize(x => x.AncillaryCharges, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.L0220, 0, 10);
		validator.CollectionSize(x => x.L0240, 1, 999999);
		validator.CollectionSize(x => x.L0260, 0, 999999);
		foreach (var item in L0220) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0240) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0260) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
