using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("ELV")]
public class ELV_EmployeeLeaveSummary : EdiX12Segment
{
	[Position(01)]
	public string EmploymentStatusCode { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public decimal? Quantity2 { get; set; }

	[Position(05)]
	public decimal? Quantity3 { get; set; }

	[Position(06)]
	public decimal? Quantity4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ELV_EmployeeLeaveSummary>(this);
		validator.Required(x=>x.EmploymentStatusCode);
		validator.Length(x => x.EmploymentStatusCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.Quantity4, 1, 15);
		return validator.Results;
	}
}
