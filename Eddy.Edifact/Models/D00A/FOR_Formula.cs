using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("FOR")]
public class FOR_Formula : EdifactSegment
{
	[Position(1)]
	public string FormulaTypeCodeQualifier { get; set; }

	[Position(2)]
	public string ObjectIdentifier { get; set; }

	[Position(3)]
	public string FormulaName { get; set; }

	[Position(4)]
	public string FreeTextValue { get; set; }

	[Position(5)]
	public C961_FormulaComplexity FormulaComplexity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FOR_Formula>(this);
		validator.Required(x=>x.FormulaTypeCodeQualifier);
		validator.Length(x => x.FormulaTypeCodeQualifier, 1, 3);
		validator.Length(x => x.ObjectIdentifier, 1, 35);
		validator.Length(x => x.FormulaName, 1, 35);
		validator.Length(x => x.FreeTextValue, 1, 512);
		return validator.Results;
	}
}
