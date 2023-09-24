using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("PID")]
public class PID_ProductItemDescription : EdiX12Segment
{
	[Position(01)]
	public string ItemDescriptionTypeCode { get; set; }

	[Position(02)]
	public string ProductProcessCharacteristicCode { get; set; }

	[Position(03)]
	public string AgencyQualifierCode { get; set; }

	[Position(04)]
	public string ProductDescriptionCode { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public string SurfaceLayerPositionCode { get; set; }

	[Position(07)]
	public string SourceSubqualifier { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(09)]
	public string LanguageCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PID_ProductItemDescription>(this);
		validator.Required(x=>x.ItemDescriptionTypeCode);
		validator.AtLeastOneIsRequired(x=>x.ProductDescriptionCode, x=>x.Description);
		validator.ARequiresB(x=>x.ProductDescriptionCode, x=>x.AgencyQualifierCode);
		validator.ARequiresB(x=>x.SourceSubqualifier, x=>x.AgencyQualifierCode);
		validator.ARequiresB(x=>x.YesNoConditionOrResponseCode, x=>x.ProductDescriptionCode);
		validator.ARequiresB(x=>x.LanguageCode, x=>x.Description);
		validator.Length(x => x.ItemDescriptionTypeCode, 1);
		validator.Length(x => x.ProductProcessCharacteristicCode, 2, 3);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.ProductDescriptionCode, 1, 12);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.SurfaceLayerPositionCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.LanguageCode, 2, 3);
		return validator.Results;
	}
}
