using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7030.Composites;

[Segment("C064")]
public class C064_ServiceType : EdiX12Component
{
	[Position(00)]
	public string IndustryCode { get; set; }

	[Position(01)]
	public string IndustryCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C064_ServiceType>(this);
		validator.Required(x=>x.IndustryCode);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.IndustryCode2, 1, 30);
		return validator.Results;
	}
}
