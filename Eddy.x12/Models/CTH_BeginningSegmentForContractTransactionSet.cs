using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CTH")]
public class CTH_BeginningSegmentForContractTransactionSet : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ContractNumber { get; set; }

	[Position(03)]
	public string ContractActionCode { get; set; }

	[Position(04)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string Date { get; set; }

	[Position(07)]
	public string Time { get; set; }

	[Position(08)]
	public string ContractLevelCode { get; set; }

	[Position(09)]
	public string ContractDateBasisCode { get; set; }

	[Position(10)]
	public string EntityIdentifierCode { get; set; }

	[Position(11)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CTH_BeginningSegmentForContractTransactionSet>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ContractNumber);
		validator.Required(x=>x.ContractActionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ContractDateBasisCode, x=>x.EntityIdentifierCode);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.ContractActionCode, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ContractLevelCode, 2);
		validator.Length(x => x.ContractDateBasisCode, 1, 2);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
