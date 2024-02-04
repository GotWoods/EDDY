using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;
using Eddy.x12.DomainModels.Transportation.v3060._422;

namespace Eddy.x12.DomainModels.Transportation.v3060;

public class Edi422_ShippersCarOrder {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BCQ_BeginningSegmentForShippersCarOrder BeginningSegmentForShippersCarOrder { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(4)] public QTY_Quantity? Quantity { get; set; }
	[SectionPosition(5)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(6)] public N1_Name Name { get; set; } = new();
	[SectionPosition(7)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(8)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(9)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(10)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(11)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi422_ShippersCarOrder>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShippersCarOrder);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 3);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 2);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLX, 1, 31);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
