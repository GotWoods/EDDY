using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Models.D99A;

[Segment("FOR")]
public class FOR_Formula : EdifactSegment
{
	[Position(1)]
	public string FormulaTypeQualifier { get; set; }

	[Position(2)]
	public string IdentityNumber { get; set; }

	[Position(3)]
	public string FormulaName { get; set; }

	[Position(4)]
	public string FreeText { get; set; }

	[Position(5)]
	public C961_FormulaComplexity FormulaComplexity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FOR_Formula>(this);
		validator.Required(x=>x.FormulaTypeQualifier);
		validator.Length(x => x.FormulaTypeQualifier, 1, 3);
		validator.Length(x => x.IdentityNumber, 1, 35);
		validator.Length(x => x.FormulaName, 1, 35);
		validator.Length(x => x.FreeText, 1, 70);
		return validator.Results;
	}
}
