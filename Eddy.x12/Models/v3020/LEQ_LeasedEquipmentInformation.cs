using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("LEQ")]
public class LEQ_LeasedEquipmentInformation : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public int? Century { get; set; }

	[Position(04)]
	public int? YearWithinCentury { get; set; }

	[Position(05)]
	public string MonthOfTheYearCode { get; set; }

	[Position(06)]
	public string ReferenceNumber2 { get; set; }

	[Position(07)]
	public string ReferenceNumber3 { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LEQ_LeasedEquipmentInformation>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.Century);
		validator.Required(x=>x.YearWithinCentury);
		validator.Required(x=>x.MonthOfTheYearCode);
		validator.Required(x=>x.ReferenceNumber2);
		validator.Required(x=>x.ReferenceNumber3);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Century, 2);
		validator.Length(x => x.YearWithinCentury, 2);
		validator.Length(x => x.MonthOfTheYearCode, 2);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.ReferenceNumber3, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		return validator.Results;
	}
}
