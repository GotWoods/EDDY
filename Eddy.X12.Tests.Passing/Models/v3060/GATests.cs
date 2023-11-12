using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class GATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GA*O*H*r*oa*u*6964*v9Y*ejnImL*f*kP*h*b*N*f*qz*L*7";

		var expected = new GA_CanadianGrainInformation()
		{
			FumigatedCleanedIndicator = "O",
			CommodityCode = "H",
			InspectedWeighedIndicatorCode = "r",
			ReferenceIdentificationQualifier = "oa",
			ReferenceIdentification = "u",
			Week = 6964,
			UnloadTerminalElevatorCode = "v9Y",
			Date = "ejnImL",
			IncentiveGrainRateIndicatorCode = "f",
			MachineSeparableIndicatorCode = "kP",
			CanadianWheatBoardCWBMarketingClassCode = "h",
			CanadianWheatBoardCWBMarketingClassTypeCode = "b",
			YesNoConditionOrResponseCode = "N",
			LocationIdentifier = "f",
			StateOrProvinceCode = "qz",
			PercentQualifier = "L",
			Percent = 7,
		};

		var actual = Map.MapObject<GA_CanadianGrainInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.CommodityCode = commodityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "f";
			subject.StateOrProvinceCode = "qz";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "L";
			subject.Percent = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "qz", true)]
	[InlineData("f", "", false)]
	[InlineData("", "qz", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.CommodityCode = "H";
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "L";
			subject.Percent = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("L", 7, true)]
	[InlineData("L", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.CommodityCode = "H";
		subject.PercentQualifier = percentQualifier;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "f";
			subject.StateOrProvinceCode = "qz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
