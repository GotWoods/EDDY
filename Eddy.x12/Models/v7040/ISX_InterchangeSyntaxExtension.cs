using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7040;

[Segment("ISX")]
public class ISX_InterchangeSyntaxExtension : EdiX12Segment
{
	[Position(01)]
	public string ReleaseCharacter { get; set; }

	[Position(02)]
	public string CharacterEncoding { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISX_InterchangeSyntaxExtension>(this);
		validator.Length(x => x.ReleaseCharacter, 1);
		validator.Length(x => x.CharacterEncoding, 1, 2);
		return validator.Results;
	}
}
