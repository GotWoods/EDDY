using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Models.D99A;

[Segment("ITD")]
public class ITD_InformationTypeData : EdifactSegment
{
	[Position(1)]
	public string InformationCategoryCoded { get; set; }

	[Position(2)]
	public string LanguageCoded { get; set; }

	[Position(3)]
	public string InformationDetailIdentification { get; set; }

	[Position(4)]
	public string DataFormatCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ITD_InformationTypeData>(this);
		validator.Length(x => x.InformationCategoryCoded, 1, 3);
		validator.Length(x => x.LanguageCoded, 1, 3);
		validator.Length(x => x.InformationDetailIdentification, 1, 17);
		validator.Length(x => x.DataFormatCoded, 1, 3);
		return validator.Results;
	}
}
