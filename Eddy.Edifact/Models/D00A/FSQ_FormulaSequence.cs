using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("FSQ")]
public class FSQ_FormulaSequence : EdifactSegment
{
	[Position(1)]
	public string FormulaSequenceCodeQualifier { get; set; }

	[Position(2)]
	public string FormulaSequenceOperandCode { get; set; }

	[Position(3)]
	public string SequencePositionIdentifier { get; set; }

	[Position(4)]
	public string FormulaSequenceName { get; set; }

	[Position(5)]
	public string FreeTextValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FSQ_FormulaSequence>(this);
		validator.Required(x=>x.FormulaSequenceCodeQualifier);
		validator.Length(x => x.FormulaSequenceCodeQualifier, 1, 3);
		validator.Length(x => x.FormulaSequenceOperandCode, 1, 17);
		validator.Length(x => x.SequencePositionIdentifier, 1, 10);
		validator.Length(x => x.FormulaSequenceName, 1, 35);
		validator.Length(x => x.FreeTextValue, 1, 512);
		return validator.Results;
	}
}
