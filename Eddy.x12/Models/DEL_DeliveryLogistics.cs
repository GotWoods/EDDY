using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("DEL")]
public class DEL_DeliveryLogistics : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(03)]
	public string IdentificationCode { get; set; }

	[Position(04)]
	public string InvoiceNumber { get; set; }

	[Position(05)]
	public string MoveTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DEL_DeliveryLogistics>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.MoveTypeCode, 1);
		return validator.Results;
	}
}
