using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("SVA")]
public class SVA_SecurityValue : EdiX12Segment
{
	[Position(01)]
	public string FilterIDCode { get; set; }

	[Position(02)]
	public string VersionIdentifier { get; set; }

	[Position(03)]
	public C033_SecurityTokenValue SecurityValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SVA_SecurityValue>(this);
		validator.Required(x=>x.FilterIDCode);
		validator.Required(x=>x.VersionIdentifier);
		validator.Required(x=>x.SecurityValue);
		validator.Length(x => x.FilterIDCode, 3);
		validator.Length(x => x.VersionIdentifier, 1, 30);
		return validator.Results;
	}
}
