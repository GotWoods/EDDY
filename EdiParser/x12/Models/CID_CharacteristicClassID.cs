using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CID")]
public class CID_CharacteristicClassID : EdiX12Segment
{
	[Position(01)]
	public string MeasurementQualifier { get; set; }

	[Position(02)]
	public string ProductProcessCharacteristicCode { get; set; }

	[Position(03)]
	public string AgencyQualifierCode { get; set; }

	[Position(04)]
	public string ProductDescriptionCode { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public string SourceSubqualifier { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CID_CharacteristicClassID>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AgencyQualifierCode, x=>x.ProductDescriptionCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.YesNoConditionOrResponseCode, x=>x.ProductDescriptionCode, x=>x.Description);
		validator.Length(x => x.MeasurementQualifier, 1, 3);
		validator.Length(x => x.ProductProcessCharacteristicCode, 2, 3);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.ProductDescriptionCode, 1, 12);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
