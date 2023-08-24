using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("CID")]
public class CID_CharacteristicClassID : EdiX12Segment
{
	[Position(01)]
	public string MeasurementQualifier { get; set; }

	[Position(02)]
	public string ProductProcessCharacteristicCode { get; set; }

	[Position(03)]
	public string AssociationQualifierCode { get; set; }

	[Position(04)]
	public string ProductDescriptionCode { get; set; }

	[Position(05)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CID_CharacteristicClassID>(this);
		validator.Length(x => x.MeasurementQualifier, 1, 3);
		validator.Length(x => x.ProductProcessCharacteristicCode, 2, 3);
		validator.Length(x => x.AssociationQualifierCode, 2);
		validator.Length(x => x.ProductDescriptionCode, 1, 12);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
