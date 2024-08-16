using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("ELM")]
public class ELM_SimpleDataElementDetails : EdifactSegment
{
	[Position(1)]
	public string SimpleDataElementTagIdentifier { get; set; }

	[Position(2)]
	public string SimpleDataElementCharacterRepresentationCode { get; set; }

	[Position(3)]
	public string LengthTypeCode { get; set; }

	[Position(4)]
	public string SimpleDataElementMaximumLengthValue { get; set; }

	[Position(5)]
	public string SimpleDataElementMinimumLengthValue { get; set; }

	[Position(6)]
	public string CodeSetIndicatorCode { get; set; }

	[Position(7)]
	public string DesignatedClassCode { get; set; }

	[Position(8)]
	public string MaintenanceOperationCode { get; set; }

	[Position(9)]
	public string SignificantDigitsQuantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ELM_SimpleDataElementDetails>(this);
		validator.Required(x=>x.SimpleDataElementTagIdentifier);
		validator.Length(x => x.SimpleDataElementTagIdentifier, 1, 4);
		validator.Length(x => x.SimpleDataElementCharacterRepresentationCode, 1, 3);
		validator.Length(x => x.LengthTypeCode, 1, 3);
		validator.Length(x => x.SimpleDataElementMaximumLengthValue, 1, 3);
		validator.Length(x => x.SimpleDataElementMinimumLengthValue, 1, 3);
		validator.Length(x => x.CodeSetIndicatorCode, 1, 3);
		validator.Length(x => x.DesignatedClassCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		validator.Length(x => x.SignificantDigitsQuantity, 1, 2);
		return validator.Results;
	}
}
