using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("LOC")]
public class LOC_PlaceLocationIdentification : EdifactSegment
{
	[Position(1)]
	public string LocationFunctionCodeQualifier { get; set; }

	[Position(2)]
	public C517_LocationIdentification LocationIdentification { get; set; }

	[Position(3)]
	public C519_RelatedLocationOneIdentification RelatedLocationOneIdentification { get; set; }

	[Position(4)]
	public C553_RelatedLocationTwoIdentification RelatedLocationTwoIdentification { get; set; }

	[Position(5)]
	public string RelationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LOC_PlaceLocationIdentification>(this);
		validator.Required(x=>x.LocationFunctionCodeQualifier);
		validator.Length(x => x.LocationFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.RelationCoded, 1, 3);
		return validator.Results;
	}
}
