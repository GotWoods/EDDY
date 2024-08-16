using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E016")]
public class E016_InsuranceCoverRequirement : EdifactComponent
{
	[Position(1)]
	public string InsuranceCoverTypeCode { get; set; }

	[Position(2)]
	public string RequirementDesignatorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E016_InsuranceCoverRequirement>(this);
		validator.Required(x=>x.InsuranceCoverTypeCode);
		validator.Length(x => x.InsuranceCoverTypeCode, 1, 3);
		validator.Length(x => x.RequirementDesignatorCoded, 1, 3);
		return validator.Results;
	}
}
