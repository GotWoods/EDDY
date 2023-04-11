using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("REN")]
public class REN_RateRequestInformation : EdiX12Segment
{
	[Position(01)]
	public string RateRequestResponseCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(05)]
	public string RateRequestResponseCode2 { get; set; }

	[Position(06)]
	public string StandardCarrierAlphaCode3 { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<REN_RateRequestInformation>(this);
		validator.Required(x=>x.RateRequestResponseCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.StandardCarrierAlphaCode, x=>x.Description);
		validator.Length(x => x.RateRequestResponseCode, 1);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.RateRequestResponseCode2, 1);
		validator.Length(x => x.StandardCarrierAlphaCode3, 2, 4);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
