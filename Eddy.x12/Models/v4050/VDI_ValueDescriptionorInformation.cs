using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("VDI")]
public class VDI_ValueDescriptionOrInformation : EdiX12Segment
{
	[Position(01)]
	public string CodeCategory { get; set; }

	[Position(02)]
	public C046_CompositeQualifierIdentifier CompositeQualifierIdentifier { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public int? Number { get; set; }

	[Position(07)]
	public int? Number2 { get; set; }

	[Position(08)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(09)]
	public string DateTimePeriod { get; set; }

	[Position(10)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	[Position(11)]
	public decimal? Quantity2 { get; set; }

	[Position(12)]
	public decimal? Multiplier { get; set; }

	[Position(13)]
	public string RoundingSystemCode { get; set; }

	[Position(14)]
	public string LoanPaymentTypeCode { get; set; }

	[Position(15)]
	public string LoanPaymentTypeCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VDI_ValueDescriptionOrInformation>(this);
		validator.ARequiresB(x=>x.Quantity, x=>x.CompositeQualifierIdentifier);
		validator.OnlyOneOf(x=>x.Quantity, x=>x.PercentageAsDecimal);
		validator.ARequiresB(x=>x.PercentageAsDecimal, x=>x.CompositeQualifierIdentifier);
		validator.ARequiresB(x=>x.MonetaryAmount, x=>x.CompositeQualifierIdentifier);
		validator.ARequiresB(x=>x.Number2, x=>x.Number);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.ARequiresB(x=>x.UnitOfTimePeriodOrInterval, x=>x.Quantity2);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Number2, 1, 9);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Multiplier, 1, 10);
		validator.Length(x => x.RoundingSystemCode, 1);
		validator.Length(x => x.LoanPaymentTypeCode, 2);
		validator.Length(x => x.LoanPaymentTypeCode2, 2);
		return validator.Results;
	}
}
