using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("RYL")]
public class RYL_RoyaltyPayment : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public string NameLastOrOrganizationName { get; set; }

	[Position(03)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(04)]
	public string IdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RYL_RoyaltyPayment>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.NameLastOrOrganizationName, 1, 35);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		return validator.Results;
	}
}
