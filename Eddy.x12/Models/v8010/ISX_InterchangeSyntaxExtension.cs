using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v8010;

[Segment("ISX")]
public class ISX_InterchangeSyntaxExtension : EdiX12Segment
{
	[Position(01)]
	public string ReleaseCharacter { get; set; }

	[Position(02)]
	public string CharacterEncoding { get; set; }

	[Position(03)]
	public string OverridingX12VersionReleaseSubreleaseCode { get; set; }

	[Position(04)]
	public string IndustryIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISX_InterchangeSyntaxExtension>(this);
		validator.ARequiresB(x=>x.IndustryIdentifier, x=>x.OverridingX12VersionReleaseSubreleaseCode);
		validator.Length(x => x.ReleaseCharacter, 1);
		validator.Length(x => x.CharacterEncoding, 1, 2);
		validator.Length(x => x.OverridingX12VersionReleaseSubreleaseCode, 6);
		validator.Length(x => x.IndustryIdentifier, 1, 15);
		return validator.Results;
	}
}
