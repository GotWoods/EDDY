using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97B.Composites;

[Segment("C593")]
public class C593_AccountIdentification : EdifactComponent
{
	[Position(1)]
	public string AccountIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string AccountAbbreviatedName { get; set; }

	[Position(5)]
	public string AccountName { get; set; }

	[Position(6)]
	public string AccountName2 { get; set; }

	[Position(7)]
	public string CurrencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C593_AccountIdentification>(this);
		validator.Required(x=>x.AccountIdentification);
		validator.Length(x => x.AccountIdentification, 1, 35);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.AccountAbbreviatedName, 1, 17);
		validator.Length(x => x.AccountName, 1, 35);
		validator.Length(x => x.AccountName2, 1, 35);
		validator.Length(x => x.CurrencyCoded, 1, 3);
		return validator.Results;
	}
}
