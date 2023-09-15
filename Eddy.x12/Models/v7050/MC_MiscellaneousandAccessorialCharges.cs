using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7050;

[Segment("MC")]
public class MC_MiscellaneousAndAccessorialCharges : EdiX12Segment
{
	[Position(01)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	[Position(02)]
	public string RateValueQualifier { get; set; }

	[Position(03)]
	public decimal? Rate { get; set; }

	[Position(04)]
	public string SpecialChargeDescription { get; set; }

	[Position(05)]
	public int? AssignedNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MC_MiscellaneousAndAccessorialCharges>(this);
		validator.Required(x=>x.SpecialChargeOrAllowanceCode);
		validator.Required(x=>x.RateValueQualifier);
		validator.Required(x=>x.Rate);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Rate, 1, 9);
		validator.Length(x => x.SpecialChargeDescription, 2, 25);
		validator.Length(x => x.AssignedNumber, 1, 9);
		return validator.Results;
	}
}
