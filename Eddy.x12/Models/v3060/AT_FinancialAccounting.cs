using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("AT")]
public class AT_FinancialAccounting : EdiX12Segment
{
	[Position(01)]
	public string IndustryCode { get; set; }

	[Position(02)]
	public string TreasurySymbolNumber { get; set; }

	[Position(03)]
	public string BudgetActivityNumber { get; set; }

	[Position(04)]
	public string ObjectClassNumber { get; set; }

	[Position(05)]
	public string ReimbursableSourceNumber { get; set; }

	[Position(06)]
	public string TransactionReferenceNumber { get; set; }

	[Position(07)]
	public string AccountableStationNumber { get; set; }

	[Position(08)]
	public string PayingStationNumber { get; set; }

	[Position(09)]
	public string Description { get; set; }

	[Position(10)]
	public string CodeListQualifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AT_FinancialAccounting>(this);
		validator.ARequiresB(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.TreasurySymbolNumber, 7, 21);
		validator.Length(x => x.BudgetActivityNumber, 1, 16);
		validator.Length(x => x.ObjectClassNumber, 3, 12);
		validator.Length(x => x.ReimbursableSourceNumber, 1, 3);
		validator.Length(x => x.TransactionReferenceNumber, 4, 20);
		validator.Length(x => x.AccountableStationNumber, 3, 8);
		validator.Length(x => x.PayingStationNumber, 8, 14);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		return validator.Results;
	}
}
