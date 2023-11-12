using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("LHT")]
public class LHT_TransborderHazardousRequirements : EdiX12Segment
{
	[Position(01)]
	public string HazardousClassification { get; set; }

	[Position(02)]
	public string HazardousPlacardNotation { get; set; }

	[Position(03)]
	public string HazardousEndorsement { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LHT_TransborderHazardousRequirements>(this);
		validator.Length(x => x.HazardousClassification, 2, 30);
		validator.Length(x => x.HazardousPlacardNotation, 14, 40);
		validator.Length(x => x.HazardousEndorsement, 4, 25);
		return validator.Results;
	}
}
