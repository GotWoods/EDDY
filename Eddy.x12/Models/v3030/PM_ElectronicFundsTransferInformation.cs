using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("PM")]
public class PM_ElectronicFundsTransferInformation : EdiX12Segment
{
	[Position(01)]
	public string DFIIdentificationNumber { get; set; }

	[Position(02)]
	public string AccountNumber { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PM_ElectronicFundsTransferInformation>(this);
		validator.Required(x=>x.DFIIdentificationNumber);
		validator.Required(x=>x.AccountNumber);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.YesNoConditionOrResponseCode2);
		validator.Length(x => x.DFIIdentificationNumber, 3, 12);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
