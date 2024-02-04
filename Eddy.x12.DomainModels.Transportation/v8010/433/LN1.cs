using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Transportation.v8010._433;

public class LN1 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public SMS_StationCodesSegment StationCodesSegment { get; set; } = new();
	[SectionPosition(3)] public List<CD_ShipmentConditions> ShipmentConditions { get; set; } = new();
	[SectionPosition(4)] public PI_PriceAuthorityIdentification? PriceAuthorityIdentification { get; set; }
	[SectionPosition(5)] public XD_PlacementPullData? PlacementPullData { get; set; }
	[SectionPosition(6)] public List<LN1_LR2B> LR2B {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.Required(x => x.StationCodesSegment);
		validator.CollectionSize(x => x.ShipmentConditions, 1, 160);
		validator.CollectionSize(x => x.LR2B, 0, 200);
		foreach (var item in LR2B) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
