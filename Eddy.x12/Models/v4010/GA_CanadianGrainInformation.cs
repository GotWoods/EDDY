using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("GA")]
public class GA_CanadianGrainInformation : EdiX12Segment
{
	[Position(01)]
	public string FumigatedCleanedIndicator { get; set; }

	[Position(02)]
	public string CommodityCode { get; set; }

	[Position(03)]
	public string InspectedWeighedIndicatorCode { get; set; }

	[Position(04)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public int? Week { get; set; }

	[Position(07)]
	public string UnloadTerminalElevatorCode { get; set; }

	[Position(08)]
	public string Date { get; set; }

	[Position(09)]
	public int? Number { get; set; }

	[Position(10)]
	public string MachineSeparableIndicatorCode { get; set; }

	[Position(11)]
	public string CanadianWheatBoardCWBMarketingClassCode { get; set; }

	[Position(12)]
	public string CanadianWheatBoardCWBMarketingClassTypeCode { get; set; }

	[Position(13)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(14)]
	public string LocationIdentifier { get; set; }

	[Position(15)]
	public string StateOrProvinceCode { get; set; }

	[Position(16)]
	public string PercentQualifier { get; set; }

	[Position(17)]
	public decimal? Percent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GA_CanadianGrainInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationIdentifier, x=>x.StateOrProvinceCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PercentQualifier, x=>x.Percent);
		validator.Length(x => x.FumigatedCleanedIndicator, 1);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.InspectedWeighedIndicatorCode, 1, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.Week, 4);
		validator.Length(x => x.UnloadTerminalElevatorCode, 3, 4);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.MachineSeparableIndicatorCode, 2);
		validator.Length(x => x.CanadianWheatBoardCWBMarketingClassCode, 1);
		validator.Length(x => x.CanadianWheatBoardCWBMarketingClassTypeCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.PercentQualifier, 1, 2);
		validator.Length(x => x.Percent, 1, 10);
		return validator.Results;
	}
}
