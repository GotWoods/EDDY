using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C785")]
public class C785_StatisticalConceptIdentification : EdifactComponent
{
	[Position(1)]
	public string StatisticalConceptIdentifier { get; set; }

	[Position(2)]
	public string ObjectIdentificationCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C785_StatisticalConceptIdentification>(this);
		validator.Required(x=>x.StatisticalConceptIdentifier);
		validator.Length(x => x.StatisticalConceptIdentifier, 1, 35);
		validator.Length(x => x.ObjectIdentificationCodeQualifier, 1, 3);
		return validator.Results;
	}
}
