using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("DEP")]
public class DEP_Deposit : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumber { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string ReferenceNumber2 { get; set; }

	[Position(05)]
	public string DFIIDNumberQualifier { get; set; }

	[Position(06)]
	public string DFIIdentificationNumber { get; set; }

	[Position(07)]
	public string AccountNumberQualifierCode { get; set; }

	[Position(08)]
	public string AccountNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DEP_Deposit>(this);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.DFIIDNumberQualifier);
		validator.Required(x=>x.DFIIdentificationNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AccountNumberQualifierCode, x=>x.AccountNumber);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.DFIIDNumberQualifier, 2);
		validator.Length(x => x.DFIIdentificationNumber, 3, 12);
		validator.Length(x => x.AccountNumberQualifierCode, 2);
		validator.Length(x => x.AccountNumber, 1, 35);
		return validator.Results;
	}
}
