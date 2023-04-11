using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("LSC")]
public class LSC_LocationScopeParameter : EdiX12Segment
{
	[Position(01)]
	public string LocationScopeParameterTypeCode { get; set; }

	[Position(02)]
	public string LocationScopeTypeCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(05)]
	public string IdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LSC_LocationScopeParameter>(this);
		validator.Required(x=>x.LocationScopeParameterTypeCode);
		validator.Required(x=>x.LocationScopeTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.LocationScopeParameterTypeCode, 2);
		validator.Length(x => x.LocationScopeTypeCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		return validator.Results;
	}
}
