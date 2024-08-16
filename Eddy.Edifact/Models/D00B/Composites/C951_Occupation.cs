using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C951")]
public class C951_Occupation : EdifactComponent
{
	[Position(1)]
	public string OccupationDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string OccupationDescription { get; set; }

	[Position(5)]
	public string OccupationDescription2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C951_Occupation>(this);
		validator.Length(x => x.OccupationDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.OccupationDescription, 1, 35);
		validator.Length(x => x.OccupationDescription2, 1, 35);
		return validator.Results;
	}
}
