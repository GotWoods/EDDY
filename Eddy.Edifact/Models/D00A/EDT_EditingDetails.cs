using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("EDT")]
public class EDT_EditingDetails : EdifactSegment
{
	[Position(1)]
	public string EditFieldLengthValue { get; set; }

	[Position(2)]
	public string EditMaskFormatIdentifier { get; set; }

	[Position(3)]
	public string EditMaskRepresentationCode { get; set; }

	[Position(4)]
	public string FreeTextFormatCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EDT_EditingDetails>(this);
		validator.Length(x => x.EditFieldLengthValue, 1, 3);
		validator.Length(x => x.EditMaskFormatIdentifier, 1, 35);
		validator.Length(x => x.EditMaskRepresentationCode, 1, 3);
		validator.Length(x => x.FreeTextFormatCode, 1, 3);
		return validator.Results;
	}
}
