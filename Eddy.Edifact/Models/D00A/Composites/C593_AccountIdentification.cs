using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C593")]
public class C593_AccountIdentification : EdifactComponent
{
	[Position(1)]
	public string AccountIdentifier { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string AccountAbbreviatedName { get; set; }

	[Position(5)]
	public string AccountName { get; set; }

	[Position(6)]
	public string AccountName2 { get; set; }

	[Position(7)]
	public string CurrencyIdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C593_AccountIdentification>(this);
		validator.Required(x=>x.AccountIdentifier);
		validator.Length(x => x.AccountIdentifier, 1, 35);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.AccountAbbreviatedName, 1, 17);
		validator.Length(x => x.AccountName, 1, 35);
		validator.Length(x => x.AccountName2, 1, 35);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		return validator.Results;
	}
}
