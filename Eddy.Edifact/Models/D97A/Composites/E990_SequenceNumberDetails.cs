using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E990")]
public class E990_SequenceNumberDetails : EdifactComponent
{
	[Position(1)]
	public string SequenceNumber { get; set; }

	[Position(2)]
	public string SequenceNumber2 { get; set; }

	[Position(3)]
	public string SequenceNumber3 { get; set; }

	[Position(4)]
	public string SequenceNumber4 { get; set; }

	[Position(5)]
	public string SequenceNumber5 { get; set; }

	[Position(6)]
	public string SequenceNumber6 { get; set; }

	[Position(7)]
	public string SequenceNumber7 { get; set; }

	[Position(8)]
	public string SequenceNumber8 { get; set; }

	[Position(9)]
	public string SequenceNumber9 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E990_SequenceNumberDetails>(this);
		validator.Required(x=>x.SequenceNumber);
		validator.Length(x => x.SequenceNumber, 1, 10);
		validator.Length(x => x.SequenceNumber2, 1, 10);
		validator.Length(x => x.SequenceNumber3, 1, 10);
		validator.Length(x => x.SequenceNumber4, 1, 10);
		validator.Length(x => x.SequenceNumber5, 1, 10);
		validator.Length(x => x.SequenceNumber6, 1, 10);
		validator.Length(x => x.SequenceNumber7, 1, 10);
		validator.Length(x => x.SequenceNumber8, 1, 10);
		validator.Length(x => x.SequenceNumber9, 1, 10);
		return validator.Results;
	}
}
