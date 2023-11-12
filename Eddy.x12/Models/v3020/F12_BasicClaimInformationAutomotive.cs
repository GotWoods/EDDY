using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("F12")]
public class F12_BasicClaimInformationAutomotive : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumber { get; set; }

	[Position(02)]
	public string ReferenceNumber2 { get; set; }

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
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.ReferenceNumber2);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.CreditDebitAdjustmentNumber);
		validator.Required(x=>x.Date2);
		validator.Required(x=>x.LaborRate);
		validator.Required(x=>x.LaborRate2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.CreditDebitAdjustmentNumber, 1, 16);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.LaborRate, 3, 4);
		validator.Length(x => x.LaborRate2, 3, 4);
		validator.Length(x => x.DamageCodeQualifier, 1);
		return validator.Results;
	}
}
