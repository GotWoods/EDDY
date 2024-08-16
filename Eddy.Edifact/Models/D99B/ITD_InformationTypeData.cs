using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("ITD")]
public class ITD_InformationTypeData : EdifactSegment
{
	[Position(1)]
	public string InformationCategoryCoded { get; set; }

	[Position(2)]
	public string LanguageNameCode { get; set; }

	[Position(3)]
	public string InformationDetailIdentification { get; set; }

	[Position(4)]
	public string DataFormatDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ITD_InformationTypeData>(this);
		validator.Length(x => x.InformationCategoryCoded, 1, 3);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		validator.Length(x => x.InformationDetailIdentification, 1, 17);
		validator.Length(x => x.DataFormatDescriptionCode, 1, 3);
		return validator.Results;
	}
}
