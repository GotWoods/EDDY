using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6050;

[Segment("TPP")]
public class TPP_ThirdPartyPayment : EdiX12Segment
{
	[Position(01)]
	public string TaxPaymentTypeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string TaxAmount { get; set; }

	[Position(05)]
	public string ReferenceIdentification2 { get; set; }

	[Position(06)]
	public string Name { get; set; }

	[Position(07)]
	public string ReferenceIdentification3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TPP_ThirdPartyPayment>(this);
		validator.Required(x=>x.TaxPaymentTypeCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.TaxAmount);
		validator.Required(x=>x.ReferenceIdentification2);
		validator.Required(x=>x.Name);
		validator.Length(x => x.TaxPaymentTypeCode, 1, 5);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.TaxAmount, 1, 10);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.ReferenceIdentification3, 1, 80);
		return validator.Results;
	}
}
