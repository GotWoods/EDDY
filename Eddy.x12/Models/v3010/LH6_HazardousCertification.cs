using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("LH6")]
public class LH6_HazardousCertification : EdiX12Segment
{
	[Position(01)]
	public string Name { get; set; }

	[Position(02)]
	public string HazardousCertificationCode { get; set; }

	[Position(03)]
	public string HazardousCertificationDeclaration { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LH6_HazardousCertification>(this);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.HazardousCertificationCode, 1);
		validator.Length(x => x.HazardousCertificationDeclaration, 1, 50);
		return validator.Results;
	}
}
