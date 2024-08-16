using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E016")]
public class E016_InsuranceCoverRequirement : EdifactComponent
{
	[Position(1)]
	public string InsuranceCoverTypeCode { get; set; }

	[Position(2)]
	public string RequirementDesignatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E016_InsuranceCoverRequirement>(this);
		validator.Required(x=>x.InsuranceCoverTypeCode);
		validator.Length(x => x.InsuranceCoverTypeCode, 1, 3);
		validator.Length(x => x.RequirementDesignatorCode, 1, 3);
		return validator.Results;
	}
}
