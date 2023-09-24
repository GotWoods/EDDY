using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TD4")]
public class TD4_CarrierDetailsSpecialHandlingHazardousMaterials : EdiX12Segment
{
	[Position(01)]
	public string SpecialHandlingCode { get; set; }

	[Position(02)]
	public string HazardousMaterialCodeQualifier { get; set; }

	[Position(03)]
	public string HazardousMaterialClassCode { get; set; }

	[Position(04)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TD4_CarrierDetailsSpecialHandlingHazardousMaterials>(this);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.HazardousMaterialCodeQualifier, 1);
		validator.Length(x => x.HazardousMaterialClassCode, 2, 4);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
