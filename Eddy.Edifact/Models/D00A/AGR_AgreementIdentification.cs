using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("AGR")]
public class AGR_AgreementIdentification : EdifactSegment
{
	[Position(1)]
	public C543_AgreementTypeIdentification AgreementTypeIdentification { get; set; }

	[Position(2)]
	public string ServiceLayerCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AGR_AgreementIdentification>(this);
		validator.Length(x => x.ServiceLayerCode, 1, 3);
		return validator.Results;
	}
}
