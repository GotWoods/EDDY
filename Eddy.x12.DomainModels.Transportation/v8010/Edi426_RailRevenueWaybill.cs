using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;
using Eddy.x12.DomainModels.Transportation.v8010._426;

namespace Eddy.x12.DomainModels.Transportation.v8010;

public class Edi426_RailRevenueWaybill {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public ZR_WaybillReferenceIdentification WaybillReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(6)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(7)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(8)] public BX_GeneralShipmentInformation? GeneralShipmentInformation { get; set; }
	[SectionPosition(9)] public List<L1000> L1000 {get;set;} = new();
	[SectionPosition(10)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi426_RailRevenueWaybill>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.WaybillReferenceIdentification);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 30);
		validator.CollectionSize(x => x.DateTimeReference, 1, 5);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 20);
		validator.Required(x => x.TransactionSetTrailer);
		foreach (var item in L1000) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
