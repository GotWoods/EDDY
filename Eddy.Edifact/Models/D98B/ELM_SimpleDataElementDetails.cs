using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Models.D98B;

[Segment("ELM")]
public class ELM_SimpleDataElementDetails : EdifactSegment
{
	[Position(1)]
	public string SimpleDataElementTag { get; set; }

	[Position(2)]
	public string SimpleDataElementCharacterRepresentationCoded { get; set; }

	[Position(3)]
	public string SimpleDataElementLengthTypeCoded { get; set; }

	[Position(4)]
	public string SimpleDataElementMaximumLength { get; set; }

	[Position(5)]
	public string SimpleDataElementMinimumLength { get; set; }

	[Position(6)]
	public string CodeSetIndicatorCoded { get; set; }

	[Position(7)]
	public string ClassDesignatorCoded { get; set; }

	[Position(8)]
	public string MaintenanceOperationCoded { get; set; }

	[Position(9)]
	public string SignificantDigits { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ELM_SimpleDataElementDetails>(this);
		validator.Required(x=>x.SimpleDataElementTag);
		validator.Length(x => x.SimpleDataElementTag, 1, 4);
		validator.Length(x => x.SimpleDataElementCharacterRepresentationCoded, 1, 3);
		validator.Length(x => x.SimpleDataElementLengthTypeCoded, 1, 3);
		validator.Length(x => x.SimpleDataElementMaximumLength, 1, 3);
		validator.Length(x => x.SimpleDataElementMinimumLength, 1, 3);
		validator.Length(x => x.CodeSetIndicatorCoded, 1, 3);
		validator.Length(x => x.ClassDesignatorCoded, 1, 3);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		validator.Length(x => x.SignificantDigits, 1, 2);
		return validator.Results;
	}
}
