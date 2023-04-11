using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("PRS")]
public class PRS_PartReleaseStatus : EdiX12Segment
{
	[Position(01)]
	public string PartReleaseStatusCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRS_PartReleaseStatus>(this);
		validator.Required(x=>x.PartReleaseStatusCode);
		validator.Length(x => x.PartReleaseStatusCode, 1, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
