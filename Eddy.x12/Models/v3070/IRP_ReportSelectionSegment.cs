using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("IRP")]
public class IRP_ReportSelectionSegment : EdiX12Segment
{
	[Position(01)]
	public string ReportTypeCode { get; set; }

	[Position(02)]
	public string ReportIdentifier { get; set; }

	[Position(03)]
	public string ReportIncrementalIndicatorCode { get; set; }

	[Position(04)]
	public string MessageDirectionCode { get; set; }

	[Position(05)]
	public string ReportStatusLevelCode { get; set; }

	[Position(06)]
	public string ReportLevelOfDetailCode { get; set; }

	[Position(07)]
	public string ShipDeliveryOrCalendarPatternCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IRP_ReportSelectionSegment>(this);
		validator.Required(x=>x.ReportTypeCode);
		validator.Length(x => x.ReportTypeCode, 1);
		validator.Length(x => x.ReportIdentifier, 1, 35);
		validator.Length(x => x.ReportIncrementalIndicatorCode, 1);
		validator.Length(x => x.MessageDirectionCode, 1);
		validator.Length(x => x.ReportStatusLevelCode, 1);
		validator.Length(x => x.ReportLevelOfDetailCode, 1);
		validator.Length(x => x.ShipDeliveryOrCalendarPatternCode, 1, 2);
		return validator.Results;
	}
}
