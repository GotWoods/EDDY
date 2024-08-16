using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E999")]
public class E999_ConnectionDetails : EdifactComponent
{
	[Position(1)]
	public string LocationNameCode { get; set; }

	[Position(2)]
	public string PartyName { get; set; }

	[Position(3)]
	public string Time { get; set; }

	[Position(4)]
	public string Time2 { get; set; }

	[Position(5)]
	public string LocationName { get; set; }

	[Position(6)]
	public string LocationFunctionCodeQualifier { get; set; }

	[Position(7)]
	public string CountryNameCode { get; set; }

	[Position(8)]
	public string SequencePositionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E999_ConnectionDetails>(this);
		validator.Length(x => x.LocationNameCode, 1, 35);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.Time2, 4);
		validator.Length(x => x.LocationName, 1, 256);
		validator.Length(x => x.LocationFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.CountryNameCode, 1, 3);
		validator.Length(x => x.SequencePositionIdentifier, 1, 10);
		return validator.Results;
	}
}
