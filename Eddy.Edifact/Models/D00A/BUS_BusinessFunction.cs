using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("BUS")]
public class BUS_BusinessFunction : EdifactSegment
{
	[Position(1)]
	public C521_BusinessFunction BusinessFunction { get; set; }

	[Position(2)]
	public string GeographicAreaCode { get; set; }

	[Position(3)]
	public string FinancialTransactionTypeCode { get; set; }

	[Position(4)]
	public C551_BankOperation BankOperation { get; set; }

	[Position(5)]
	public string IntraCompanyPaymentIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BUS_BusinessFunction>(this);
		validator.Length(x => x.GeographicAreaCode, 1, 3);
		validator.Length(x => x.FinancialTransactionTypeCode, 1, 3);
		validator.Length(x => x.IntraCompanyPaymentIndicatorCode, 1, 3);
		return validator.Results;
	}
}
