using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("IFD")]
public class IFD_InformationDetail : EdifactSegment
{
	[Position(1)]
	public string InformationDetailsCodeQualifier { get; set; }

	[Position(2)]
	public C009_InformationCategory InformationCategory { get; set; }

	[Position(3)]
	public C010_InformationType InformationType { get; set; }

	[Position(4)]
	public C011_InformationDetail InformationDetail { get; set; }

	[Position(5)]
	public string StatusDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IFD_InformationDetail>(this);
		validator.Length(x => x.InformationDetailsCodeQualifier, 1, 3);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		return validator.Results;
	}
}
