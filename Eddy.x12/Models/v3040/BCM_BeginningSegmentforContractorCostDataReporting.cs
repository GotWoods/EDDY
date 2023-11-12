using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("BCM")]
public class BCM_BeginningSegmentForContractorCostDataReporting : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Date2 { get; set; }

	[Position(04)]
	public string ContractNumber { get; set; }

	[Position(05)]
	public string FreeFormDescription { get; set; }

	[Position(06)]
	public string ContractActionCode { get; set; }

	[Position(07)]
	public string ProgramTypeCode { get; set; }

	[Position(08)]
	public string FreeFormDescription2 { get; set; }

	[Position(09)]
	public string ContractingFundingCode { get; set; }

	[Position(10)]
	public string ContractTypeCode { get; set; }

	[Position(11)]
	public string SecurityLevelCode { get; set; }

	[Position(12)]
	public string CurrencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BCM_BeginningSegmentForContractorCostDataReporting>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Date2);
		validator.AtLeastOneIsRequired(x=>x.ContractNumber, x=>x.FreeFormDescription);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.ContractActionCode, 2);
		validator.Length(x => x.ProgramTypeCode, 2);
		validator.Length(x => x.FreeFormDescription2, 1, 45);
		validator.Length(x => x.ContractingFundingCode, 2);
		validator.Length(x => x.ContractTypeCode, 2);
		validator.Length(x => x.SecurityLevelCode, 2);
		validator.Length(x => x.CurrencyCode, 3);
		return validator.Results;
	}
}
