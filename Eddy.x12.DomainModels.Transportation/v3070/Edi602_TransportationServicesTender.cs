using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;
using Eddy.x12.DomainModels.Transportation.v3070._602;

namespace Eddy.x12.DomainModels.Transportation.v3070;

public class Edi602_TransportationServicesTender {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public DK_DocketHeader DocketHeader { get; set; } = new();
	[SectionPosition(3)] public List<PRI_ExternalReferenceIdentifier> ExternalReferenceIdentifier { get; set; } = new();
	[SectionPosition(4)] public SS_DocketControlStatus? DocketControlStatus { get; set; }
	[SectionPosition(5)] public List<SA_StatusAction> StatusAction { get; set; } = new();
	[SectionPosition(6)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(7)] public List<CD_ShipmentConditions> ShipmentConditions { get; set; } = new();
	[SectionPosition(8)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(9)] public List<L0200> L0200 {get;set;} = new();

	//Details
	[SectionPosition(10)] public List<L0300> L0300 {get;set;} = new();

	//Summary
	[SectionPosition(11)] public List<MS_MiscellaneousServices> MiscellaneousServices { get; set; } = new();
	[SectionPosition(12)] public List<DM_DemurrageDetentionStorageRate> DemurrageDetentionStorageRate { get; set; } = new();
	[SectionPosition(13)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi602_TransportationServicesTender>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.DocketHeader);
		validator.CollectionSize(x => x.ExternalReferenceIdentifier, 0, 12);
		validator.CollectionSize(x => x.StatusAction, 0, 5);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 5);
		validator.CollectionSize(x => x.ShipmentConditions, 0, 20);
		

		validator.CollectionSize(x => x.L0100, 0, 200);
		validator.CollectionSize(x => x.L0200, 0, 100);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.L0300, 0, 99);
		foreach (var item in L0300) validator.Results.AddRange(item.Validate().Errors);
		validator.CollectionSize(x => x.MiscellaneousServices, 0, 200);
		validator.CollectionSize(x => x.DemurrageDetentionStorageRate, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
