using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("BCP")]
public class BCP_BeginningSegmentForContractPricingProposal : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string ContractActionCode { get; set; }

	[Position(06)]
	public string ContractTypeCode { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	[Position(08)]
	public string Time { get; set; }

	[Position(09)]
	public string ChangeOrderSequenceNumber { get; set; }

	[Position(10)]
	public string ReferenceIdentification2 { get; set; }

	[Position(11)]
	public string ReferenceIdentification3 { get; set; }

	[Position(12)]
	public string Description { get; set; }

	[Position(13)]
	public string Description2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BCP_BeginningSegmentForContractPricingProposal>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.ContractActionCode, 2);
		validator.Length(x => x.ContractTypeCode, 2);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ChangeOrderSequenceNumber, 1, 8);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.ReferenceIdentification3, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Description2, 1, 80);
		return validator.Results;
	}
}
