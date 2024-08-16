using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("EFI")]
public class EFI_ExternalFileLinkIdentification : EdifactSegment
{
	[Position(1)]
	public C077_FileIdentification FileIdentification { get; set; }

	[Position(2)]
	public C099_FileDetails FileDetails { get; set; }

	[Position(3)]
	public string SequenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EFI_ExternalFileLinkIdentification>(this);
		validator.Required(x=>x.FileIdentification);
		validator.Length(x => x.SequenceNumber, 1, 6);
		return validator.Results;
	}
}
