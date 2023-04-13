using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G40")]
public class G40_BracketPrice : EdiX12Segment
{
	[Position(01)]
	public string PriceBracketIdentifier { get; set; }

	[Position(02)]
	public decimal? ItemListCostNew { get; set; }

	[Position(03)]
	public decimal? ItemListCostOld { get; set; }

	[Position(04)]
	public string FreeFormDescription { get; set; }

	[Position(05)]
	public string PriceNewSuggestedRetail { get; set; }

	[Position(06)]
	public string PriceOldSuggestedRetail { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(08)]
	public string PriceIdentifierCode { get; set; }

	[Position(09)]
	public int? Number { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G40_BracketPrice>(this);
		validator.Required(x=>x.ItemListCostNew);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.ItemListCostNew, 1, 9);
		validator.Length(x => x.ItemListCostOld, 1, 9);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.PriceNewSuggestedRetail, 2, 7);
		validator.Length(x => x.PriceOldSuggestedRetail, 2, 7);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.PriceIdentifierCode, 3);
		validator.Length(x => x.Number, 1, 9);
		return validator.Results;
	}
}
