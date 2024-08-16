using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C595")]
public class C595_AccountingJournalIdentification : EdifactComponent
{
	[Position(1)]
	public string AccountingJournalIdentification { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string AccountingJournal { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C595_AccountingJournalIdentification>(this);
		validator.Required(x=>x.AccountingJournalIdentification);
		validator.Length(x => x.AccountingJournalIdentification, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.AccountingJournal, 1, 35);
		return validator.Results;
	}
}
