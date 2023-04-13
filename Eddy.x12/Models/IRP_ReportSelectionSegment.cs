using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("IRP")]
public class IRP_ReportSelectionSegment : EdiX12Segment
{
	[Position(01)]
	public string InterchangeReportTypeCode { get; set; }

	[Position(02)]
	public string InterchangeReportIdentifier { get; set; }

	[Position(03)]
	public string InterchangeReportIncrementalIndicatorCode { get; set; }

	[Position(04)]
	public string InterchangeMessageDirectionCode { get; set; }

	[Position(05)]
	public string InterchangeReportStatusLevelCode { get; set; }

	[Position(06)]
	public string InterchangeReportLevelOfDetailCode { get; set; }

	[Position(07)]
	public string ShipDeliveryOrCalendarPatternCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IRP_ReportSelectionSegment>(this);
		validator.Required(x=>x.InterchangeReportTypeCode);
		validator.Length(x => x.InterchangeReportTypeCode, 1);
		validator.Length(x => x.InterchangeReportIdentifier, 1, 35);
		validator.Length(x => x.InterchangeReportIncrementalIndicatorCode, 1);
		validator.Length(x => x.InterchangeMessageDirectionCode, 1);
		validator.Length(x => x.InterchangeReportStatusLevelCode, 1);
		validator.Length(x => x.InterchangeReportLevelOfDetailCode, 1);
		validator.Length(x => x.ShipDeliveryOrCalendarPatternCode, 1, 2);
		return validator.Results;
	}
}
