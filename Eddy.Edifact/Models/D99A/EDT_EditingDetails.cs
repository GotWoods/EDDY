using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Models.D99A;

[Segment("EDT")]
public class EDT_EditingDetails : EdifactSegment
{
	[Position(1)]
	public string EditFieldLength { get; set; }

	[Position(2)]
	public string EditMask { get; set; }

	[Position(3)]
	public string EditMaskRepresentationCode { get; set; }

	[Position(4)]
	public string TextFormattingCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EDT_EditingDetails>(this);
		validator.Length(x => x.EditFieldLength, 1, 3);
		validator.Length(x => x.EditMask, 1, 35);
		validator.Length(x => x.EditMaskRepresentationCode, 1, 3);
		validator.Length(x => x.TextFormattingCoded, 1, 3);
		return validator.Results;
	}
}
