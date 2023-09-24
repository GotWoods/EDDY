using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("X2")]
public class X2_ImportLicense : EdiX12Segment
{
	[Position(01)]
	public string ImportLicenseNumber { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Date2 { get; set; }

	[Position(04)]
	public string ImportLicenseNumber2 { get; set; }

	[Position(05)]
	public string Date3 { get; set; }

	[Position(06)]
	public string Date4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<X2_ImportLicense>(this);
		validator.Required(x=>x.ImportLicenseNumber);
		validator.ARequiresB(x=>x.Date3, x=>x.ImportLicenseNumber2);
		validator.ARequiresB(x=>x.Date4, x=>x.ImportLicenseNumber2);
		validator.Length(x => x.ImportLicenseNumber, 6, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.ImportLicenseNumber2, 6, 30);
		validator.Length(x => x.Date3, 6);
		validator.Length(x => x.Date4, 6);
		return validator.Results;
	}
}
