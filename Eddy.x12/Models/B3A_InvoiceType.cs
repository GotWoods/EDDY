using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("B3A")]
public class B3A_InvoiceType : EdiX12Segment 
{
	[Position(01)]
	public string TransactionTypeCode { get; set; }

	[Position(02)]
	public int? NumberOfShipments { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B3A_InvoiceType>(this);
		validator.Required(x=>x.TransactionTypeCode);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.NumberOfShipments, 1, 5);
		return validator.Results;
	}
}
