using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("PRT")]
public class PRT_PartDisposition : EdiX12Segment
{
	[Position(01)]
	public string DispositionCode { get; set; }

	[Position(02)]
	public string AgencyQualifierCode { get; set; }

	[Position(03)]
	public string SourceSubqualifier { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRT_PartDisposition>(this);
		validator.Required(x=>x.DispositionCode);
		validator.ARequiresB(x=>x.SourceSubqualifier, x=>x.AgencyQualifierCode);
		validator.Length(x => x.DispositionCode, 3);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
