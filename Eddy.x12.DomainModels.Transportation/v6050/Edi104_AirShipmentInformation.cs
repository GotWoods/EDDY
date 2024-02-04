using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;
using Eddy.x12.DomainModels.Transportation.v6050._104;

namespace Eddy.x12.DomainModels.Transportation.v6050;

public class Edi104_AirShipmentInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(3)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(4)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(8)] public P1_Pickup? Pickup { get; set; }
	[SectionPosition(9)] public G47_StatementIdentification? StatementIdentification { get; set; }
	[SectionPosition(10)] public F9_OriginStation? OriginStation { get; set; }

	//Details
	[SectionPosition(11)] public List<LFOB> LFOB {get;set;} = new();

	//Summary
	[SectionPosition(12)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(13)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(14)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi104_AirShipmentInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		

		validator.CollectionSize(x => x.LFOB, 1, 99999);
		foreach (var item in LFOB) validator.Results.AddRange(item.Validate().Errors);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
