using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._110;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<LLX_LN1> LN1 {get;set;} = new();
	[SectionPosition(3)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(4)] public List<L4_Measurement> Measurement { get; set; } = new();
	[SectionPosition(5)] public P1_PickUp? PickUp { get; set; }
	[SectionPosition(6)] public POD_ProofOfDelivery? ProofOfDelivery { get; set; }
	[SectionPosition(7)] public V9_EventDetail? EventDetail { get; set; }
	[SectionPosition(8)] public List<ACS_AncillaryCharges> AncillaryCharges { get; set; } = new();
	[SectionPosition(9)] public G47_StatementIdentification? StatementIdentification { get; set; }
	[SectionPosition(10)] public List<RMT_RemittanceAdvice> RemittanceAdvice { get; set; } = new();
	[SectionPosition(11)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(12)] public List<LLX_LL5> LL5 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.Measurement, 0, 30);
		validator.CollectionSize(x => x.AncillaryCharges, 0, 1000);
		validator.CollectionSize(x => x.RemittanceAdvice, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.LN1, 0, 2);
		validator.CollectionSize(x => x.LL5, 1, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LL5) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
