using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("GEI")]
public class GEI_ProcessingInformation : EdifactSegment
{
	[Position(1)]
	public string ProcessingInformationCodeQualifier { get; set; }

	[Position(2)]
	public C012_ProcessingIndicator ProcessingIndicator { get; set; }

	[Position(3)]
	public string ProcessTypeDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GEI_ProcessingInformation>(this);
		validator.Required(x=>x.ProcessingInformationCodeQualifier);
		validator.Length(x => x.ProcessingInformationCodeQualifier, 1, 3);
		validator.Length(x => x.ProcessTypeDescriptionCode, 1, 17);
		return validator.Results;
	}
}
