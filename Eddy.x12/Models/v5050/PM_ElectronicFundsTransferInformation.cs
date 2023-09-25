using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5050;

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

	[Position(05)]
	public string AccountNumberQualifier { get; set; }

	[Position(06)]
	public string DFIIDNumberQualifier { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode4 { get; set; }

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
		validator.Length(x => x.AccountNumberQualifier, 1, 3);
		validator.Length(x => x.DFIIDNumberQualifier, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode4, 1);
		return validator.Results;
	}
}
