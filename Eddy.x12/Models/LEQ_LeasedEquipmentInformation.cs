using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("LEQ")]
public class LEQ_LeasedEquipmentInformation : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public int? Year { get; set; }

	[Position(04)]
	public string MonthOfTheYearCode { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public string ReferenceIdentification2 { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount { get; set; }

	[Position(08)]
	public string Date { get; set; }

	[Position(09)]
	public decimal? ExchangeRate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LEQ_LeasedEquipmentInformation>(this);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Year);
		validator.Required(x=>x.MonthOfTheYearCode);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.ReferenceIdentification2);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Year, 4);
		validator.Length(x => x.MonthOfTheYearCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ExchangeRate, 4, 10);
		return validator.Results;
	}
}
