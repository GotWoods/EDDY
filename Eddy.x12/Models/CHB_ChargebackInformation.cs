using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CHB")]
public class CHB_ChargebackInformation : EdiX12Segment
{
	[Position(01)]
	public string LocationQualifier { get; set; }

	[Position(02)]
	public string LocationIdentifier { get; set; }

	[Position(03)]
	public string ReasonStoppedWorkCode { get; set; }

	[Position(04)]
	public string ClaimTypeCode { get; set; }

	[Position(05)]
	public string ClaimStatusCode { get; set; }

	[Position(06)]
	public string EntityIdentifierCode { get; set; }

	[Position(07)]
	public string CreditDebitFlagCode { get; set; }

	[Position(08)]
	public string IndustryCode { get; set; }

	[Position(09)]
	public string AllowanceOrChargeIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CHB_ChargebackInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.ReasonStoppedWorkCode, 2);
		validator.Length(x => x.ClaimTypeCode, 1, 2);
		validator.Length(x => x.ClaimStatusCode, 1, 2);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.AllowanceOrChargeIndicatorCode, 1);
		return validator.Results;
	}
}
