using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("SCD")]
public class SCD_SalesCommissionEmployeeDetail : EdiX12Segment
{
	[Position(01)]
	public string EmploymentStatusCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string EmploymentStatusCode2 { get; set; }

	[Position(04)]
	public string Date2 { get; set; }

	[Position(05)]
	public string AgencyQualifierCode { get; set; }

	[Position(06)]
	public string IndustryCode { get; set; }

	[Position(07)]
	public string GenderCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCD_SalesCommissionEmployeeDetail>(this);
		validator.Required(x=>x.EmploymentStatusCode);
		validator.ARequiresB(x=>x.Date2, x=>x.EmploymentStatusCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AgencyQualifierCode, x=>x.IndustryCode);
		validator.Length(x => x.EmploymentStatusCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.EmploymentStatusCode2, 2);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.GenderCode, 1);
		return validator.Results;
	}
}
