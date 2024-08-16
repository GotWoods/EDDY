using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("S010")]
public class S010_StatusOfTheTransfer : EdifactComponent
{
	[Position(1)]
	public string SequenceOfTransfers { get; set; }

	[Position(2)]
	public string FirstAndLastTransfer { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S010_StatusOfTheTransfer>(this);
		validator.Required(x=>x.SequenceOfTransfers);
		validator.Length(x => x.SequenceOfTransfers, 1, 2);
		validator.Length(x => x.FirstAndLastTransfer, 1);
		return validator.Results;
	}
}
