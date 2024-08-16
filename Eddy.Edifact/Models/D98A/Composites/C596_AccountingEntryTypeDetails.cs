using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98A.Composites;

[Segment("C596")]
public class C596_AccountingEntryTypeDetails : EdifactComponent
{
	[Position(1)]
	public string TypeOfAccountingEntryIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string TypeOfAccountingEntry { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C596_AccountingEntryTypeDetails>(this);
		validator.Required(x=>x.TypeOfAccountingEntryIdentification);
		validator.Length(x => x.TypeOfAccountingEntryIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.TypeOfAccountingEntry, 1, 35);
		return validator.Results;
	}
}