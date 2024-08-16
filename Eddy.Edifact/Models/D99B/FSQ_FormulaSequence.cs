using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("FSQ")]
public class FSQ_FormulaSequence : EdifactSegment
{
	[Position(1)]
	public string FormulaSequenceQualifier { get; set; }

	[Position(2)]
	public string FormulaSequenceOperandIdentification { get; set; }

	[Position(3)]
	public string SequenceNumber { get; set; }

	[Position(4)]
	public string FormulaSequenceName { get; set; }

	[Position(5)]
	public string FreeTextValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FSQ_FormulaSequence>(this);
		validator.Required(x=>x.FormulaSequenceQualifier);
		validator.Length(x => x.FormulaSequenceQualifier, 1, 3);
		validator.Length(x => x.FormulaSequenceOperandIdentification, 1, 17);
		validator.Length(x => x.SequenceNumber, 1, 10);
		validator.Length(x => x.FormulaSequenceName, 1, 35);
		validator.Length(x => x.FreeTextValue, 1, 512);
		return validator.Results;
	}
}
