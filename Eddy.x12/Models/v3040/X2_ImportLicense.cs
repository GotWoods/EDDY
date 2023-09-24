using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("X2")]
public class X2_ImportLicense : EdiX12Segment
{
	[Position(01)]
	public string ImportLicenseNumber { get; set; }

	[Position(02)]
	public string ImportLicenseIssueDate { get; set; }

	[Position(03)]
	public string ImportLicenseExpirationDate { get; set; }

	[Position(04)]
	public string ImportLicenseNumber2 { get; set; }

	[Position(05)]
	public string ImportLicenseIssueDate2 { get; set; }

	[Position(06)]
	public string ImportLicenseExpirationDate2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<X2_ImportLicense>(this);
		validator.Required(x=>x.ImportLicenseNumber);
		validator.ARequiresB(x=>x.ImportLicenseIssueDate2, x=>x.ImportLicenseNumber2);
		validator.ARequiresB(x=>x.ImportLicenseExpirationDate2, x=>x.ImportLicenseNumber2);
		validator.Length(x => x.ImportLicenseNumber, 6, 30);
		validator.Length(x => x.ImportLicenseIssueDate, 6);
		validator.Length(x => x.ImportLicenseExpirationDate, 6);
		validator.Length(x => x.ImportLicenseNumber2, 6, 30);
		validator.Length(x => x.ImportLicenseIssueDate2, 6);
		validator.Length(x => x.ImportLicenseExpirationDate2, 6);
		return validator.Results;
	}
}
