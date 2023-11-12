using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("FAA")]
public class FAA_FinancialAssetAccount : EdiX12Segment
{
	[Position(01)]
	public string AccountNumberQualifierCode { get; set; }

	[Position(02)]
	public string AccountNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public string TypeOfAccount { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(08)]
	public decimal? Quantity { get; set; }

	[Position(09)]
	public string DateTimeQualifier { get; set; }

	[Position(10)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(11)]
	public string DateTimePeriod { get; set; }

	[Position(12)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(13)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FAA_FinancialAssetAccount>(this);
		validator.Required(x=>x.AccountNumberQualifierCode);
		validator.Required(x=>x.AccountNumber);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.TypeOfAccount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.ARequiresB(x=>x.DateTimeQualifier, x=>x.DateTimePeriod);
		validator.ARequiresB(x=>x.DateTimePeriod, x=>x.DateTimePeriodFormatQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.Length(x => x.AccountNumberQualifierCode, 2);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.TypeOfAccount, 2);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
