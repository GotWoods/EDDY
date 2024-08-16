using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E946")]
public class E946_Certainty : EdifactComponent
{
	[Position(1)]
	public string CertaintyDescriptionCode { get; set; }

	[Position(2)]
	public string CertaintyDescription { get; set; }

	[Position(3)]
	public string LanguageNameCode { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E946_Certainty>(this);
		validator.Length(x => x.CertaintyDescriptionCode, 1, 3);
		validator.Length(x => x.CertaintyDescription, 1, 35);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
