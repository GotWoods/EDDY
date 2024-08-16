using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("CTA")]
public class CTA_ContactInformation : EdifactSegment
{
	[Position(1)]
	public string ContactFunctionCode { get; set; }

	[Position(2)]
	public C056_DepartmentOrEmployeeDetails DepartmentOrEmployeeDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CTA_ContactInformation>(this);
		validator.Length(x => x.ContactFunctionCode, 1, 3);
		return validator.Results;
	}
}