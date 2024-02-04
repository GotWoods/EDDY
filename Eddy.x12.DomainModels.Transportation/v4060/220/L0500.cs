using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060._220;

public class L0500 {
	[SectionPosition(1)] public LCD_PlaceLocationDescription PlaceLocationDescription { get; set; } = new();
	[SectionPosition(2)] public List<ITA_AllowanceChargeOrService> AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(3)] public List<L8_LineItemSubtotal> LineItemSubtotal { get; set; } = new();
	[SectionPosition(4)] public List<L9_ChargeDetail> ChargeDetail { get; set; } = new();
	[SectionPosition(5)] public List<L3_TotalWeightAndCharges> TotalWeightAndCharges { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0500>(this);
		validator.Required(x => x.PlaceLocationDescription);
		validator.CollectionSize(x => x.AllowanceChargeOrService, 0, 999);
		validator.CollectionSize(x => x.LineItemSubtotal, 0, 999);
		validator.CollectionSize(x => x.ChargeDetail, 0, 999);
		validator.CollectionSize(x => x.TotalWeightAndCharges, 0, 999);
		return validator.Results;
	}
}
