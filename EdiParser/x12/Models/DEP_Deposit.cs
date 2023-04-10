using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("DEP")]
public class DEP_Deposit : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string ReferenceIdentification2 { get; set; }

	[Position(05)]
	public string DFIIDNumberQualifier { get; set; }

	[Position(06)]
	public string DFIIdentificationNumber { get; set; }

	[Position(07)]
	public string AccountNumberQualifier { get; set; }

	[Position(08)]
	public string AccountNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DEP_Deposit>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.DFIIDNumberQualifier);
		validator.Required(x=>x.DFIIdentificationNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AccountNumberQualifier, x=>x.AccountNumber);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.DFIIDNumberQualifier, 2);
		validator.Length(x => x.DFIIdentificationNumber, 3, 12);
		validator.Length(x => x.AccountNumberQualifier, 1, 3);
		validator.Length(x => x.AccountNumber, 1, 35);
		return validator.Results;
	}
}
