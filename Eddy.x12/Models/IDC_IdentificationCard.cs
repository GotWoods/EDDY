using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("IDC")]
public class IDC_IdentificationCard : EdiX12Segment
{
	[Position(01)]
	public string PlanCoverageDescription { get; set; }

	[Position(02)]
	public string IdentificationCardTypeCode { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IDC_IdentificationCard>(this);
		validator.Required(x=>x.PlanCoverageDescription);
		validator.Required(x=>x.IdentificationCardTypeCode);
		validator.Length(x => x.PlanCoverageDescription, 1, 50);
		validator.Length(x => x.IdentificationCardTypeCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
