using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("EFI")]
public class EFI_ExternalFileLinkIdentification : EdifactSegment
{
	[Position(1)]
	public C077_FileIdentification FileIdentification { get; set; }

	[Position(2)]
	public C099_FileDetails FileDetails { get; set; }

	[Position(3)]
	public string SequencePositionIdentifier { get; set; }

	[Position(4)]
	public string FileCompressionTechniqueName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EFI_ExternalFileLinkIdentification>(this);
		validator.Required(x=>x.FileIdentification);
		validator.Length(x => x.SequencePositionIdentifier, 1, 10);
		validator.Length(x => x.FileCompressionTechniqueName, 1, 35);
		return validator.Results;
	}
}