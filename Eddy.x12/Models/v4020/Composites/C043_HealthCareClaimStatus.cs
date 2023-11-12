using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020.Composites;

[Segment("C043")]
public class C043_HealthCareClaimStatus : EdiX12Component
{
	[Position(00)]
	public string IndustryCode { get; set; }

	[Position(01)]
	public string IndustryCode2 { get; set; }

	[Position(02)]
	public string EntityIdentifierCode { get; set; }

	[Position(03)]
	public string CodeListQualifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C043_HealthCareClaimStatus>(this);
		validator.Required(x=>x.IndustryCode);
		validator.Required(x=>x.IndustryCode2);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.IndustryCode2, 1, 30);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		return validator.Results;
	}
}
