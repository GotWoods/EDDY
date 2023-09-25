using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("IMM")]
public class IMM_ImmunizationStatusCode : EdiX12Segment
{
	[Position(01)]
	public string ImmunizationTypeCode { get; set; }

	[Position(02)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriod { get; set; }

	[Position(04)]
	public string ImmunizationStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IMM_ImmunizationStatusCode>(this);
		validator.Required(x=>x.ImmunizationTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.ARequiresB(x=>x.DateTimePeriod, x=>x.ImmunizationStatusCode);
		validator.Length(x => x.ImmunizationTypeCode, 3, 6);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.ImmunizationStatusCode, 1, 2);
		return validator.Results;
	}
}
