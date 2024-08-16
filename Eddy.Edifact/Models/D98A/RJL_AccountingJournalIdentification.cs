using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Models.D98A;

[Segment("RJL")]
public class RJL_AccountingJournalIdentification : EdifactSegment
{
	[Position(1)]
	public C595_AccountingJournalIdentification AccountingJournalIdentification { get; set; }

	[Position(2)]
	public C596_AccountingEntryTypeDetails AccountingEntryTypeDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RJL_AccountingJournalIdentification>(this);
		return validator.Results;
	}
}
