using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("TEM")]
public class TEM_TestMethod : EdifactSegment
{
	[Position(1)]
	public C244_TestMethod TestMethod { get; set; }

	[Position(2)]
	public string TestRouteOfAdministeringCoded { get; set; }

	[Position(3)]
	public string TestMediaCoded { get; set; }

	[Position(4)]
	public string MeasurementPurposeQualifier { get; set; }

	[Position(5)]
	public string TestRevisionNumber { get; set; }

	[Position(6)]
	public C515_TestReason TestReason { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TEM_TestMethod>(this);
		validator.Length(x => x.TestRouteOfAdministeringCoded, 1, 3);
		validator.Length(x => x.TestMediaCoded, 1, 3);
		validator.Length(x => x.MeasurementPurposeQualifier, 1, 3);
		validator.Length(x => x.TestRevisionNumber, 1, 30);
		return validator.Results;
	}
}