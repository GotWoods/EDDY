using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("TCD")]
public class TCD_ItemizedCallDetail : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string LocationQualifier { get; set; }

	[Position(05)]
	public string LocationIdentifier { get; set; }

	[Position(06)]
	public string StateOrProvinceCode { get; set; }

	[Position(07)]
	public string LocationQualifier2 { get; set; }

	[Position(08)]
	public string LocationIdentifier2 { get; set; }

	[Position(09)]
	public string StateOrProvinceCode2 { get; set; }

	[Position(10)]
	public decimal? MeasurementValue { get; set; }

	[Position(11)]
	public decimal? MeasurementValue2 { get; set; }

	[Position(12)]
	public decimal? MonetaryAmount { get; set; }

	[Position(13)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(14)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(15)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(16)]
	public string RelationshipCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TCD_ItemizedCallDetail>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier2, x=>x.LocationIdentifier2);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.LocationQualifier2, 1, 2);
		validator.Length(x => x.LocationIdentifier2, 1, 30);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.MeasurementValue, 1, 20);
		validator.Length(x => x.MeasurementValue2, 1, 20);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.MonetaryAmount4, 1, 15);
		validator.Length(x => x.RelationshipCode, 1);
		return validator.Results;
	}
}
