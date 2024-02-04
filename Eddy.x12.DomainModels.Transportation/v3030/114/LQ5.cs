using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._114;

public class LQ5 {
	[SectionPosition(1)] public Q5_StatusDetails StatusDetails { get; set; } = new();
	[SectionPosition(2)] public N9_ReferenceNumber? ReferenceNumber { get; set; }
	[SectionPosition(3)] public List<Q7_LadingExceptionCode> LadingExceptionCode { get; set; } = new();
	[SectionPosition(4)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(5)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(6)] public G86_Signature? Signature { get; set; }
	[SectionPosition(7)] public Q6_ShipmentDetails? ShipmentDetails { get; set; }
	[SectionPosition(8)] public Q1_StatusDetailsAir? StatusDetailsAir { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LQ5>(this);
		validator.Required(x => x.StatusDetails);
		validator.CollectionSize(x => x.LadingExceptionCode, 0, 10);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 10);
		return validator.Results;
	}
}
