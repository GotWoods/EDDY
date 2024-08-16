using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("E979")]
public class E979_ReservationControlIdentification : EdifactComponent
{
	[Position(1)]
	public string PartyName { get; set; }

	[Position(2)]
	public string ReservationIdentifier { get; set; }

	[Position(3)]
	public string ReservationIdentifierCodeQualifier { get; set; }

	[Position(4)]
	public string DateValue { get; set; }

	[Position(5)]
	public string MillisecondTimeValue { get; set; }

	[Position(6)]
	public string ReferenceIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E979_ReservationControlIdentification>(this);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.ReservationIdentifier, 1, 20);
		validator.Length(x => x.ReservationIdentifierCodeQualifier, 1, 3);
		validator.Length(x => x.DateValue, 1, 14);
		validator.Length(x => x.MillisecondTimeValue, 9);
		validator.Length(x => x.ReferenceIdentifier, 1, 70);
		return validator.Results;
	}
}
