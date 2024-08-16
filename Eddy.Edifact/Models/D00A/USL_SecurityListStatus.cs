using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("USL")]
public class USL_SecurityListStatus : EdifactSegment
{
	[Position(1)]
	public string SecurityStatusCoded { get; set; }

	[Position(2)]
	public S504_ListParameter ListParameter { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USL_SecurityListStatus>(this);
		validator.Required(x=>x.SecurityStatusCoded);
		validator.Length(x => x.SecurityStatusCoded, 1, 3);
		return validator.Results;
	}
}
