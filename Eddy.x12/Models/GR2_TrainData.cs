using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("GR2")]
public class GR2_TrainData : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string LocationQualifier { get; set; }

	[Position(03)]
	public string LocationIdentifier { get; set; }

	[Position(04)]
	public string CityName { get; set; }

	[Position(05)]
	public string StateOrProvinceCode { get; set; }

	[Position(06)]
	public string CountryCode { get; set; }

	[Position(07)]
	public string InterchangeTrainIdentification { get; set; }

	[Position(08)]
	public string Date { get; set; }

	[Position(09)]
	public string Time { get; set; }

	[Position(10)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(11)]
	public string StandardCarrierAlphaCode3 { get; set; }

	[Position(12)]
	public string InterchangeTrainIdentification2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GR2_TrainData>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.AtLeastOneIsRequired(x=>x.LocationIdentifier, x=>x.CityName);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CityName, x=>x.StateOrProvinceCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.InterchangeTrainIdentification, 1, 10);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode3, 2, 4);
		validator.Length(x => x.InterchangeTrainIdentification2, 1, 10);
		return validator.Results;
	}
}
