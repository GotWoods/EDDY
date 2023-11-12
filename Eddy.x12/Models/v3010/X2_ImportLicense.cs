using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("X2")]
public class X2_ImportLicense : EdiX12Segment
{
	[Position(01)]
	public string ImportLicenseNumber { get; set; }

	[Position(02)]
	public string ImportLicenseIssueDate { get; set; }

	[Position(03)]
	public string ImportLicenseExpirationDate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<X2_ImportLicense>(this);
		validator.Required(x=>x.ImportLicenseNumber);
		validator.Required(x=>x.ImportLicenseIssueDate);
		validator.Length(x => x.ImportLicenseNumber, 6, 30);
		validator.Length(x => x.ImportLicenseIssueDate, 6);
		validator.Length(x => x.ImportLicenseExpirationDate, 6);
		return validator.Results;
	}
}
