using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("BUS")]
public class BUS_BusinessFunction : EdifactSegment
{
	[Position(1)]
	public C521_BusinessFunction BusinessFunction { get; set; }

	[Position(2)]
	public string GeographicEnvironmentCoded { get; set; }

	[Position(3)]
	public string TypeOfFinancialTransactionCoded { get; set; }

	[Position(4)]
	public C551_BankOperation BankOperation { get; set; }

	[Position(5)]
	public string IntraCompanyPaymentCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BUS_BusinessFunction>(this);
		validator.Length(x => x.GeographicEnvironmentCoded, 1, 3);
		validator.Length(x => x.TypeOfFinancialTransactionCoded, 1, 3);
		validator.Length(x => x.IntraCompanyPaymentCoded, 1, 3);
		return validator.Results;
	}
}
