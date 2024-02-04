using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Transportation.v5010._215;

public class L0200_L0240 {
	[SectionPosition(1)] public CD3_CartonPackageDetail CartonPackageDetail { get; set; } = new();
	[SectionPosition(2)] public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();
	[SectionPosition(3)] public MS4_ShipmentOrPackageDimensions? ShipmentOrPackageDimensions { get; set; }
	[SectionPosition(4)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(5)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(6)] public List<MS6_ShipmentQuantityAndWeight> ShipmentQuantityAndWeight { get; set; } = new();
	[SectionPosition(7)] public List<ACS_AncillaryCharges> AncillaryCharges { get; set; } = new();
	[SectionPosition(8)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(9)] public List<L0200__L0240_L0250> L0250 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0240>(this);
		validator.Required(x => x.CartonPackageDetail);
		validator.CollectionSize(x => x.MarksAndNumbersInformation, 0, 100);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 10);
		validator.CollectionSize(x => x.ShipmentQuantityAndWeight, 0, 5);
		validator.CollectionSize(x => x.AncillaryCharges, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.L0250, 0, 999999);
		foreach (var item in L0250) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
