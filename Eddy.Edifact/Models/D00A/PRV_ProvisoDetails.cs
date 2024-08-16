using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("PRV")]
public class PRV_ProvisoDetails : EdifactSegment
{
	[Position(1)]
	public string ProvisoCodeQualifier { get; set; }

	[Position(2)]
	public C971_ProvisoType ProvisoType { get; set; }

	[Position(3)]
	public C972_ProvisoCalculation ProvisoCalculation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRV_ProvisoDetails>(this);
		validator.Required(x=>x.ProvisoCodeQualifier);
		validator.Length(x => x.ProvisoCodeQualifier, 1, 3);
		return validator.Results;
	}
}
