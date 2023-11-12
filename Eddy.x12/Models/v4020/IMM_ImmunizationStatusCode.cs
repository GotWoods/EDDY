using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("IMM")]
public class IMM_ImmunizationStatusCode : EdiX12Segment
{
	[Position(01)]
	public string IndustryCode { get; set; }

	[Position(02)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriod { get; set; }

	[Position(04)]
	public string ImmunizationStatusCode { get; set; }

	[Position(05)]
	public string ReportTypeCode { get; set; }

	[Position(06)]
	public string CodeListQualifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IMM_ImmunizationStatusCode>(this);
		validator.Required(x=>x.IndustryCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.ARequiresB(x=>x.DateTimePeriod, x=>x.ImmunizationStatusCode);
		validator.Required(x=>x.CodeListQualifierCode);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.ImmunizationStatusCode, 1, 2);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		return validator.Results;
	}
}
