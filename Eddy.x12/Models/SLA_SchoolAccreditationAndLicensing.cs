using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SLA")]
public class SLA_SchoolAccreditationAndLicensing : EdiX12Segment
{
	[Position(01)]
	public string CodeListQualifierCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public string CodeForLicensingCertificationRegistrationOrAccreditationAgency { get; set; }

	[Position(04)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(05)]
	public string DateTimePeriod { get; set; }

	[Position(06)]
	public string CodeListQualifierCode2 { get; set; }

	[Position(07)]
	public string IndustryCode2 { get; set; }

	[Position(08)]
	public string StateOrProvinceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SLA_SchoolAccreditationAndLicensing>(this);
		validator.Required(x=>x.CodeListQualifierCode);
		validator.Required(x=>x.IndustryCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode2, x=>x.IndustryCode2);
		validator.OnlyOneOf(x=>x.StateOrProvinceCode, x=>x.CodeListQualifierCode2);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.CodeForLicensingCertificationRegistrationOrAccreditationAgency, 1, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.CodeListQualifierCode2, 1, 3);
		validator.Length(x => x.IndustryCode2, 1, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		return validator.Results;
	}
}
