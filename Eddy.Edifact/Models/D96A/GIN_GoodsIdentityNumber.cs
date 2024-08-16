using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("GIN")]
public class GIN_GoodsIdentityNumber : EdifactSegment
{
	[Position(1)]
	public string IdentityNumberQualifier { get; set; }

	[Position(2)]
	public C208_IdentityNumberRange IdentityNumberRange { get; set; }

	[Position(3)]
	public C208_IdentityNumberRange IdentityNumberRange2 { get; set; }

	[Position(4)]
	public C208_IdentityNumberRange IdentityNumberRange3 { get; set; }

	[Position(5)]
	public C208_IdentityNumberRange IdentityNumberRange4 { get; set; }

	[Position(6)]
	public C208_IdentityNumberRange IdentityNumberRange5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GIN_GoodsIdentityNumber>(this);
		validator.Required(x=>x.IdentityNumberQualifier);
		validator.Required(x=>x.IdentityNumberRange);
		validator.Length(x => x.IdentityNumberQualifier, 1, 3);
		return validator.Results;
	}
}
