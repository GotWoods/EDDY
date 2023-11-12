using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("C2")]
public class C2_BankID : EdiX12Segment
{
	[Position(01)]
	public string BankClientCode { get; set; }

	[Position(02)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(03)]
	public string IdentificationCode { get; set; }

	[Position(04)]
	public string ClientBankNumber { get; set; }

	[Position(05)]
	public string BankAccountNumber { get; set; }

	[Position(06)]
	public string PaymentMethodTypeCode { get; set; }

	[Position(07)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C2_BankID>(this);
		validator.Required(x=>x.BankClientCode);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.Length(x => x.BankClientCode, 1);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.ClientBankNumber, 3, 9);
		validator.Length(x => x.BankAccountNumber, 6, 17);
		validator.Length(x => x.PaymentMethodTypeCode, 1, 2);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
