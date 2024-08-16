using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("TEM")]
public class TEM_TestMethod : EdifactSegment
{
	[Position(1)]
	public C244_TestMethod TestMethod { get; set; }

	[Position(2)]
	public string TestAdministrationMethodCode { get; set; }

	[Position(3)]
	public string TestMediumCode { get; set; }

	[Position(4)]
	public string MeasurementAttributeCode { get; set; }

	[Position(5)]
	public string TestMethodRevisionIdentifier { get; set; }

	[Position(6)]
	public C515_TestReason TestReason { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TEM_TestMethod>(this);
		validator.Length(x => x.TestAdministrationMethodCode, 1, 3);
		validator.Length(x => x.TestMediumCode, 1, 3);
		validator.Length(x => x.MeasurementAttributeCode, 1, 3);
		validator.Length(x => x.TestMethodRevisionIdentifier, 1, 30);
		return validator.Results;
	}
}
