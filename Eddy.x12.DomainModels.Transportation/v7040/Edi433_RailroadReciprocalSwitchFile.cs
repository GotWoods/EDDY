using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;
using Eddy.x12.DomainModels.Transportation.v7040._433;

namespace Eddy.x12.DomainModels.Transportation.v7040;

public class Edi433_RailroadReciprocalSwitchFile {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(5)] public SMS_StationCodesSegment StationCodesSegment { get; set; } = new();
	[SectionPosition(6)] public List<CD_ShipmentConditions> ShipmentConditions { get; set; } = new();
	[SectionPosition(7)] public PI_PriceAuthorityIdentification? PriceAuthorityIdentification { get; set; }
	[SectionPosition(8)] public XD_PlacementPullData? PlacementPullData { get; set; }
	[SectionPosition(9)] public List<LR2B> LR2B {get;set;} = new();
	[SectionPosition(10)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(11)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi433_RailroadReciprocalSwitchFile>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateTimeReference, 1, 10);
		validator.Required(x => x.PartyIdentification);
		validator.Required(x => x.StationCodesSegment);
		validator.CollectionSize(x => x.ShipmentConditions, 0, 160);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LR2B, 0, 200);
		validator.CollectionSize(x => x.LN1, 0, 50);
		foreach (var item in LR2B) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
