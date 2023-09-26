using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("AT5")]
public class AT5_BillOfLadingHandlingRequirements : EdiX12Segment
{
	[Position(01)]
	public string SpecialHandlingCode { get; set; }

	[Position(02)]
	public string SpecialServicesCode { get; set; }

	[Position(03)]
	public string SpecialHandlingDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AT5_BillOfLadingHandlingRequirements>(this);
		validator.OnlyOneOf(x=>x.SpecialHandlingCode, x=>x.SpecialHandlingDescription);
		validator.OnlyOneOf(x=>x.SpecialServicesCode, x=>x.SpecialHandlingDescription);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.SpecialServicesCode, 2, 10);
		validator.Length(x => x.SpecialHandlingDescription, 2, 30);
		return validator.Results;
	}
}
