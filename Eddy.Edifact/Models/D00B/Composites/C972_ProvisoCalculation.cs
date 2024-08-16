using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C972")]
public class C972_ProvisoCalculation : EdifactComponent
{
	[Position(1)]
	public string ProvisoCalculationDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ProvisoCalculationDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C972_ProvisoCalculation>(this);
		validator.Length(x => x.ProvisoCalculationDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ProvisoCalculationDescription, 1, 35);
		return validator.Results;
	}
}
