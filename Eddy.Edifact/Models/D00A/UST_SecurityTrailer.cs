using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UST")]
public class UST_SecurityTrailer : EdifactSegment
{
	[Position(1)]
	public string SecurityReferenceNumber { get; set; }

	[Position(2)]
	public string NumberOfSecuritySegments { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UST_SecurityTrailer>(this);
		validator.Required(x=>x.SecurityReferenceNumber);
		validator.Required(x=>x.NumberOfSecuritySegments);
		validator.Length(x => x.SecurityReferenceNumber, 1, 14);
		validator.Length(x => x.NumberOfSecuritySegments, 1, 10);
		return validator.Results;
	}
}
