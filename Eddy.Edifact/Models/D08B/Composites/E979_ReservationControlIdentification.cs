using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D08B.Composites;

[Segment("E979")]
public class E979_ReservationControlInformation : EdifactComponent
{
	[Position(1)]
	public string PartyName { get; set; }

	[Position(2)]
	public string ReservationIdentifier { get; set; }

	[Position(3)]
	public string ReservationIdentifierCodeQualifier { get; set; }

	[Position(4)]
	public string Date { get; set; }

	[Position(5)]
	public string MillisecondTime { get; set; }

	[Position(6)]
	public string ReferenceIdentifier { get; set; }

	[Position(7)]
	public string AdjustmentReasonDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E979_ReservationControlInformation>(this);
		validator.Length(x => x.PartyName, 1, 70);
		validator.Length(x => x.ReservationIdentifier, 1, 20);
		validator.Length(x => x.ReservationIdentifierCodeQualifier, 1, 3);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.MillisecondTime, 9);
		validator.Length(x => x.ReferenceIdentifier, 1, 70);
		validator.Length(x => x.AdjustmentReasonDescriptionCode, 1, 3);
		return validator.Results;
	}
}
