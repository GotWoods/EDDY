using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("COD")]
public class COD_ComponentDetails : EdifactSegment
{
	[Position(1)]
	public C823_TypeOfUnitComponent TypeOfUnitComponent { get; set; }

	[Position(2)]
	public C824_ComponentMaterial ComponentMaterial { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<COD_ComponentDetails>(this);
		return validator.Results;
	}
}
