using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("PID")]
public class PID_ProductItemDescription : EdiX12Segment
{
	[Position(01)]
	public string ItemDescriptionType { get; set; }

	[Position(02)]
	public string ProductProcessCharacteristicCode { get; set; }

	[Position(03)]
	public string AssociationQualifierCode { get; set; }

	[Position(04)]
	public string ProductDescriptionCode { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public string SurfaceLayerPositionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PID_ProductItemDescription>(this);
		validator.Required(x=>x.ItemDescriptionType);
		validator.Length(x => x.ItemDescriptionType, 1);
		validator.Length(x => x.ProductProcessCharacteristicCode, 2, 3);
		validator.Length(x => x.AssociationQualifierCode, 2);
		validator.Length(x => x.ProductDescriptionCode, 1, 12);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.SurfaceLayerPositionCode, 2);
		return validator.Results;
	}
}
