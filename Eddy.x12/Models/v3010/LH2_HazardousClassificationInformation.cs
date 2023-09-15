using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("LH2")]
public class LH2_HazardousClassificationInformation : EdiX12Segment
{
	[Position(01)]
	public string HazardousClassification { get; set; }

	[Position(02)]
	public string HazardousClassQualifier { get; set; }

	[Position(03)]
	public string HazardousPlacardNotation { get; set; }

	[Position(04)]
	public string HazardousEndorsement { get; set; }

	[Position(05)]
	public string ReportableQuantityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LH2_HazardousClassificationInformation>(this);
		validator.Required(x=>x.HazardousClassification);
		validator.Length(x => x.HazardousClassification, 2, 30);
		validator.Length(x => x.HazardousClassQualifier, 1);
		validator.Length(x => x.HazardousPlacardNotation, 16, 40);
		validator.Length(x => x.HazardousEndorsement, 4, 25);
		validator.Length(x => x.ReportableQuantityCode, 2);
		return validator.Results;
	}
}
