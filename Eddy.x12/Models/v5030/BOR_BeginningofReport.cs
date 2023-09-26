using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("BOR")]
public class BOR_BeginningOfReport : EdiX12Segment
{
	[Position(01)]
	public string ReportTypeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string ReferenceIdentification2 { get; set; }

	[Position(04)]
	public string ReferenceIdentification3 { get; set; }

	[Position(05)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(06)]
	public string DateTimePeriod { get; set; }

	[Position(07)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(08)]
	public string ActionCode { get; set; }

	[Position(09)]
	public string StatusReasonCode { get; set; }

	[Position(10)]
	public string LanguageCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BOR_BeginningOfReport>(this);
		validator.Required(x=>x.ReportTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.ReferenceIdentification3, 1, 80);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.LanguageCode, 2, 3);
		return validator.Results;
	}
}
