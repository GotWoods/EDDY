using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Models.D01C;

[Segment("ITD")]
public class ITD_InformationTypeData : EdifactSegment
{
	[Position(1)]
	public string InformationCategoryCode { get; set; }

	[Position(2)]
	public string LanguageNameCode { get; set; }

	[Position(3)]
	public string StatusDescriptionCode { get; set; }

	[Position(4)]
	public string DataFormatDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ITD_InformationTypeData>(this);
		validator.Length(x => x.InformationCategoryCode, 1, 3);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		validator.Length(x => x.DataFormatDescriptionCode, 1, 3);
		return validator.Results;
	}
}
