using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("NCD")]
public class NCD_NonconformanceDescription : EdiX12Segment
{
	[Position(01)]
	public string MeasurementAttributeCode { get; set; }

	[Position(02)]
	public string NonconformanceDeterminationCode { get; set; }

	[Position(03)]
	public string AssignedIdentification { get; set; }

	[Position(04)]
	public string ProductProcessCharacteristicCode { get; set; }

	[Position(05)]
	public string AssociationQualifierCode { get; set; }

	[Position(06)]
	public string ProductDescriptionCode { get; set; }

	[Position(07)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NCD_NonconformanceDescription>(this);
		validator.Required(x=>x.MeasurementAttributeCode);
		validator.Length(x => x.MeasurementAttributeCode, 2);
		validator.Length(x => x.NonconformanceDeterminationCode, 1);
		validator.Length(x => x.AssignedIdentification, 1, 6);
		validator.Length(x => x.ProductProcessCharacteristicCode, 2, 3);
		validator.Length(x => x.AssociationQualifierCode, 2);
		validator.Length(x => x.ProductDescriptionCode, 1, 12);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
