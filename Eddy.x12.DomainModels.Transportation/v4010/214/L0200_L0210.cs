using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._214;

public class L0200_L0210 {
	[SectionPosition(1)] public CD3_CartonPackageDetail CartonPackageDetail { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<L0200__L0210_L0215> L0215 {get;set;} = new();
	[SectionPosition(4)] public NM1_IndividualOrOrganizationalName? IndividualOrOrganizationalName { get; set; }
	[SectionPosition(5)] public List<Q7_LadingExceptionCode> LadingExceptionCode { get; set; } = new();
	[SectionPosition(6)] public AT8_ShipmentWeightPackagingAndQuantityData? ShipmentWeightPackagingAndQuantityData { get; set; }
	[SectionPosition(7)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(8)] public List<L0200__L0210_L0220> L0220 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0210>(this);
		validator.Required(x => x.CartonPackageDetail);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 20);
		validator.CollectionSize(x => x.LadingExceptionCode, 0, 10);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 9999);
		validator.CollectionSize(x => x.L0215, 0, 10);
		validator.CollectionSize(x => x.L0220, 0, 999999);
		foreach (var item in L0215) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0220) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
