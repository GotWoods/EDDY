using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._214;

public class L0200_L0210 {
	[SectionPosition(1)] public CD3_CartonPackageDetail CartonPackageDetail { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<Q5_StatusDetails> StatusDetails { get; set; } = new();
	[SectionPosition(4)] public NM1_IndividualOrOrganizationalName? IndividualOrOrganizationalName { get; set; }
	[SectionPosition(5)] public List<Q7_LadingExceptionCode> LadingExceptionCode { get; set; } = new();
	[SectionPosition(6)] public Q6_ShipmentDetails? ShipmentDetails { get; set; }
	[SectionPosition(7)] public List<L0200__L0210_L0211> L0211 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0210>(this);
		validator.Required(x => x.CartonPackageDetail);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 20);
		validator.CollectionSize(x => x.StatusDetails, 0, 10);
		validator.CollectionSize(x => x.LadingExceptionCode, 0, 10);
		validator.CollectionSize(x => x.L0211, 0, 999999);
		foreach (var item in L0211) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
