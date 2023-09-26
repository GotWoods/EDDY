using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("FDA")]
public class FDA_FacilityDescription : EdiX12Segment
{
	[Position(01)]
	public string PropertyOwnershipRightsCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string TypeOfRealEstateAssetCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string FreeFormMessage { get; set; }

	[Position(07)]
	public string ConstructionType { get; set; }

	[Position(08)]
	public string ConstructionType2 { get; set; }

	[Position(09)]
	public string Description2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FDA_FacilityDescription>(this);
		validator.AtLeastOneIsRequired(x=>x.PropertyOwnershipRightsCode, x=>x.Description);
		validator.ARequiresB(x=>x.YesNoConditionOrResponseCode, x=>x.TypeOfRealEstateAssetCode);
		validator.OnlyOneOf(x=>x.YesNoConditionOrResponseCode, x=>x.Quantity);
		validator.ARequiresB(x=>x.Quantity, x=>x.TypeOfRealEstateAssetCode);
		validator.ARequiresB(x=>x.ConstructionType2, x=>x.ConstructionType);
		validator.Length(x => x.PropertyOwnershipRightsCode, 1);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.TypeOfRealEstateAssetCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.FreeFormMessage, 1, 30);
		validator.Length(x => x.ConstructionType, 1);
		validator.Length(x => x.ConstructionType2, 1);
		validator.Length(x => x.Description2, 1, 80);
		return validator.Results;
	}
}
