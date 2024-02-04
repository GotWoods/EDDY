using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Transportation.v3040._214;

public class L0200 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<Q5_StatusDetails> StatusDetails { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(5)] public List<Q7_LadingExceptionCode> LadingExceptionCode { get; set; } = new();
	[SectionPosition(6)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(7)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(8)] public G86_Signature? Signature { get; set; }
	[SectionPosition(9)] public Q6_ShipmentDetails? ShipmentDetails { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.StatusDetails, 0, 10);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 300);
		validator.CollectionSize(x => x.LadingExceptionCode, 0, 10);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 10);
		return validator.Results;
	}
}
