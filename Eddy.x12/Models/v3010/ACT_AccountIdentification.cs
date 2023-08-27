using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("ACT")]
public class ACT_AccountIdentification : EdiX12Segment
{
	[Position(01)]
	public string AccountNumber { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(04)]
	public string IdentificationCode { get; set; }

	[Position(05)]
	public string AccountNumberQualifier { get; set; }

	[Position(06)]
	public string AccountNumber2 { get; set; }

	[Position(07)]
	public string FreeFormMessage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ACT_AccountIdentification>(this);
		validator.Required(x=>x.AccountNumber);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.AccountNumberQualifier, 1, 3);
		validator.Length(x => x.AccountNumber2, 1, 35);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		return validator.Results;
	}
}
