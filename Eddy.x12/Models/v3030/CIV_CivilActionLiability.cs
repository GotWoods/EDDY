using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("CIV")]
public class CIV_CivilActionLiability : EdiX12Segment
{
	[Position(01)]
	public string PublicRecordOrObligationCode { get; set; }

	[Position(02)]
	public string AmountQualifierCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public string RateValueQualifier { get; set; }

	[Position(05)]
	public string Name { get; set; }

	[Position(06)]
	public string Name2 { get; set; }

	[Position(07)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(08)]
	public string ReferenceNumber { get; set; }

	[Position(09)]
	public string CityName { get; set; }

	[Position(10)]
	public string CountyDesignator { get; set; }

	[Position(11)]
	public string StateOrProvinceCode { get; set; }

	[Position(12)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(13)]
	public string DateTimePeriod { get; set; }

	[Position(14)]
	public string DateTimeQualifier { get; set; }

	[Position(15)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(16)]
	public string DateTimePeriod2 { get; set; }

	[Position(17)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CIV_CivilActionLiability>(this);
		validator.Required(x=>x.PublicRecordOrObligationCode);
		validator.Required(x=>x.AmountQualifierCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier2, x=>x.DateTimePeriod2);
		validator.Length(x => x.PublicRecordOrObligationCode, 2);
		validator.Length(x => x.AmountQualifierCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.Name2, 1, 35);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.CountyDesignator, 5);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
