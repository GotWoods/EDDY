using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E023")]
public class E023_PartyDemographicInformation : EdifactComponent
{
	[Position(1)]
	public string RelationshipDescriptionCode { get; set; }

	[Position(2)]
	public string GenderCode { get; set; }

	[Position(3)]
	public string EmploymentCategoryDescriptionCode { get; set; }

	[Position(4)]
	public string MaritalStatusDescriptionCode { get; set; }

	[Position(5)]
	public string StatusDescriptionCode { get; set; }

	[Position(6)]
	public string YesOrNoIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E023_PartyDemographicInformation>(this);
		validator.Length(x => x.RelationshipDescriptionCode, 1, 3);
		validator.Length(x => x.GenderCode, 1, 3);
		validator.Length(x => x.EmploymentCategoryDescriptionCode, 1, 3);
		validator.Length(x => x.MaritalStatusDescriptionCode, 1, 3);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		validator.Length(x => x.YesOrNoIndicatorCode, 1, 3);
		return validator.Results;
	}
}
