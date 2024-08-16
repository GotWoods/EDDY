using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S022")]
public class S022_StatusOfTheObject : EdifactComponent
{
	[Position(1)]
	public string LengthOfObjectInOctetsOfBits { get; set; }

	[Position(2)]
	public string NumberOfSegmentsBeforeObject { get; set; }

	[Position(3)]
	public string SequenceOfTransfers { get; set; }

	[Position(4)]
	public string FirstAndLastTransfer { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S022_StatusOfTheObject>(this);
		validator.Required(x=>x.LengthOfObjectInOctetsOfBits);
		validator.Length(x => x.LengthOfObjectInOctetsOfBits, 1, 18);
		validator.Length(x => x.NumberOfSegmentsBeforeObject, 1, 3);
		validator.Length(x => x.SequenceOfTransfers, 1, 2);
		validator.Length(x => x.FirstAndLastTransfer, 1);
		return validator.Results;
	}
}
