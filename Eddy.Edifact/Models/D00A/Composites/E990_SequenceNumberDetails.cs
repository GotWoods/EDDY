using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E990")]
public class E990_SequenceNumberDetails : EdifactComponent
{
	[Position(1)]
	public string SequencePositionIdentifier { get; set; }

	[Position(2)]
	public string SequencePositionIdentifier2 { get; set; }

	[Position(3)]
	public string SequencePositionIdentifier3 { get; set; }

	[Position(4)]
	public string SequencePositionIdentifier4 { get; set; }

	[Position(5)]
	public string SequencePositionIdentifier5 { get; set; }

	[Position(6)]
	public string SequencePositionIdentifier6 { get; set; }

	[Position(7)]
	public string SequencePositionIdentifier7 { get; set; }

	[Position(8)]
	public string SequencePositionIdentifier8 { get; set; }

	[Position(9)]
	public string SequencePositionIdentifier9 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E990_SequenceNumberDetails>(this);
		validator.Required(x=>x.SequencePositionIdentifier);
		validator.Length(x => x.SequencePositionIdentifier, 1, 10);
		validator.Length(x => x.SequencePositionIdentifier2, 1, 10);
		validator.Length(x => x.SequencePositionIdentifier3, 1, 10);
		validator.Length(x => x.SequencePositionIdentifier4, 1, 10);
		validator.Length(x => x.SequencePositionIdentifier5, 1, 10);
		validator.Length(x => x.SequencePositionIdentifier6, 1, 10);
		validator.Length(x => x.SequencePositionIdentifier7, 1, 10);
		validator.Length(x => x.SequencePositionIdentifier8, 1, 10);
		validator.Length(x => x.SequencePositionIdentifier9, 1, 10);
		return validator.Results;
	}
}
