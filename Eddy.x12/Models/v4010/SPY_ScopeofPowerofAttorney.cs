using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("SPY")]
public class SPY_ScopeOfPowerOfAttorney : EdiX12Segment
{
	[Position(01)]
	public string ActionCode { get; set; }

	[Position(02)]
	public string ScopeOfPowerOfAttorneyIdentificationCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SPY_ScopeOfPowerOfAttorney>(this);
		validator.Required(x=>x.ActionCode);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.ScopeOfPowerOfAttorneyIdentificationCode, 1, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
