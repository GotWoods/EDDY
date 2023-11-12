using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Models.v7060;

[Segment("PDH")]
public class PDH_PharmaceuticalDrugInformation : EdiX12Segment
{
	[Position(01)]
	public string RouteOfAdministrationForPharmaceuticalDrugs { get; set; }

	[Position(02)]
	public C068_CompositeIngredientInformation CompositeIngredientInformation { get; set; }

	[Position(03)]
	public string DosageFormForPharmaceuticalDrugs { get; set; }

	[Position(04)]
	public C068_CompositeIngredientInformation CompositeIngredientInformation2 { get; set; }

	[Position(05)]
	public string BiomedicalHazard { get; set; }

	[Position(06)]
	public C068_CompositeIngredientInformation CompositeIngredientInformation3 { get; set; }

	[Position(07)]
	public string TradeItemDrugBrandingType { get; set; }

	[Position(08)]
	public string ShapeCode { get; set; }

	[Position(09)]
	public C068_CompositeIngredientInformation CompositeIngredientInformation4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDH_PharmaceuticalDrugInformation>(this);
		validator.OnlyOneOf(x=>x.RouteOfAdministrationForPharmaceuticalDrugs, x=>x.CompositeIngredientInformation);
		validator.OnlyOneOf(x=>x.DosageFormForPharmaceuticalDrugs, x=>x.CompositeIngredientInformation2);
		validator.OnlyOneOf(x=>x.BiomedicalHazard, x=>x.CompositeIngredientInformation3);
		validator.OnlyOneOf(x=>x.ShapeCode, x=>x.CompositeIngredientInformation4);
		validator.Length(x => x.RouteOfAdministrationForPharmaceuticalDrugs, 2, 3);
		validator.Length(x => x.DosageFormForPharmaceuticalDrugs, 4);
		validator.Length(x => x.BiomedicalHazard, 1, 2);
		validator.Length(x => x.TradeItemDrugBrandingType, 2);
		validator.Length(x => x.ShapeCode, 1, 2);
		return validator.Results;
	}
}
