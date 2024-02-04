using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._214;

public class L0200_L0210 {
	[SectionPosition(1)] public CD3_CartonPackageDetail CartonPackageDetail { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructions> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<Q5_StatusDetails> StatusDetails { get; set; } = new();
	[SectionPosition(4)] public NM1_IndividualOrOrganizationalName? IndividualOrOrganizationalName { get; set; }
	[SectionPosition(5)] public List<Q7_LadingExceptionCode> LadingExceptionCode { get; set; } = new();
	[SectionPosition(6)] public AT8_ShipmentWeightPackagingAndQuantityData? ShipmentWeightPackagingAndQuantityData { get; set; }
	[SectionPosition(7)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(8)] public List<L0200__L0210_L0211> L0211 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0210>(this);
		validator.Required(x => x.CartonPackageDetail);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 20);
		validator.CollectionSize(x => x.StatusDetails, 0, 10);
		validator.CollectionSize(x => x.LadingExceptionCode, 0, 10);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 9999);
		validator.CollectionSize(x => x.L0211, 0, 999999);
		foreach (var item in L0211) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
