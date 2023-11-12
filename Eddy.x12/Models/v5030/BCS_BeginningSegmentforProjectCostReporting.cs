using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030.Composites;

namespace Eddy.x12.Models.v5030;

[Segment("BCS")]
public class BCS_BeginningSegmentForProjectCostReporting : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string ContractNumber { get; set; }

	[Position(04)]
	public string Date2 { get; set; }

	[Position(05)]
	public string ContractTypeCode { get; set; }

	[Position(06)]
	public string Description { get; set; }

	[Position(07)]
	public string ReferenceIdentification { get; set; }

	[Position(08)]
	public string ProgramTypeCode { get; set; }

	[Position(09)]
	public string SecurityLevelCode { get; set; }

	[Position(10)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(11)]
	public decimal? PercentageAsDecimal2 { get; set; }

	[Position(12)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BCS_BeginningSegmentForProjectCostReporting>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.ContractNumber);
		validator.Required(x=>x.Date2);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.ContractTypeCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ProgramTypeCode, 2);
		validator.Length(x => x.SecurityLevelCode, 2);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.PercentageAsDecimal2, 1, 10);
		return validator.Results;
	}
}
