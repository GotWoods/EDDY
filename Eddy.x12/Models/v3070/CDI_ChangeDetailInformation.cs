using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Models.v3070;

[Segment("CDI")]
public class CDI_ChangeDetailInformation : EdiX12Segment
{
	[Position(01)]
	public string OptionTypeCode { get; set; }

	[Position(02)]
	public C045_ConditionsIndicated ConditionsIndicated { get; set; }

	[Position(03)]
	public string ConvertibilityRateTypeCode { get; set; }

	[Position(04)]
	public string StatusReasonCode { get; set; }

	[Position(05)]
	public string RateValueQualifier { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	[Position(07)]
	public int? Number { get; set; }

	[Position(08)]
	public int? Number2 { get; set; }

	[Position(09)]
	public string IndexIdentityCode { get; set; }

	[Position(10)]
	public string FreeFormMessageText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CDI_ChangeDetailInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RateValueQualifier, x=>x.Quantity);
		validator.ARequiresB(x=>x.Number2, x=>x.Number);
		validator.Length(x => x.OptionTypeCode, 1, 2);
		validator.Length(x => x.ConvertibilityRateTypeCode, 1, 2);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Number2, 1, 9);
		validator.Length(x => x.IndexIdentityCode, 2);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		return validator.Results;
	}
}
