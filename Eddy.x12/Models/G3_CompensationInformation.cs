using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G3")]
public class G3_CompensationInformation : EdiX12Segment
{
	[Position(01)]
	public decimal? CompensationPaid { get; set; }

	[Position(02)]
	public int? TotalCompensationAmount { get; set; }

	[Position(03)]
	public string Name { get; set; }

	[Position(04)]
	public string BusinessTransactionStatusCode { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public string CompensationQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G3_CompensationInformation>(this);
		validator.Required(x=>x.TotalCompensationAmount);
		validator.Length(x => x.CompensationPaid, 2, 5);
		validator.Length(x => x.TotalCompensationAmount, 3, 10);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.BusinessTransactionStatusCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.CompensationQualifier, 1);
		return validator.Results;
	}
}
