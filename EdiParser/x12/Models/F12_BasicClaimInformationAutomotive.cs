using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("F12")]
public class F12_BasicClaimInformationAutomotive : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string ReferenceIdentification2 { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string CreditDebitAdjustmentNumber { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public string LaborRate { get; set; }

	[Position(07)]
	public string LaborRate2 { get; set; }

	[Position(08)]
	public string DamageCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F12_BasicClaimInformationAutomotive>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.ReferenceIdentification2);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.CreditDebitAdjustmentNumber);
		validator.Required(x=>x.Date2);
		validator.Required(x=>x.LaborRate);
		validator.Required(x=>x.LaborRate2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.CreditDebitAdjustmentNumber, 1, 22);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.LaborRate, 3, 6);
		validator.Length(x => x.LaborRate2, 3, 6);
		validator.Length(x => x.DamageCodeQualifier, 1);
		return validator.Results;
	}
}
