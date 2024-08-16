using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("RSL")]
public class RSL_Result : EdifactSegment
{
	[Position(1)]
	public string ResultValueTypeCodeQualifier { get; set; }

	[Position(2)]
	public string ResultTypeCoded { get; set; }

	[Position(3)]
	public C831_ResultDetails ResultDetails { get; set; }

	[Position(4)]
	public C831_ResultDetails ResultDetails2 { get; set; }

	[Position(5)]
	public C848_MeasurementUnitDetails MeasurementUnitDetails { get; set; }

	[Position(6)]
	public string ResultNormalcyIndicatorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RSL_Result>(this);
		validator.Required(x=>x.ResultValueTypeCodeQualifier);
		validator.Length(x => x.ResultValueTypeCodeQualifier, 1, 3);
		validator.Length(x => x.ResultTypeCoded, 1, 3);
		validator.Length(x => x.ResultNormalcyIndicatorCoded, 1, 3);
		return validator.Results;
	}
}
