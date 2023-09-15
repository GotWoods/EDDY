using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class GATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GA*5*5*B*hI*3*4346*JV9*gfOVXbYt*7*pY*q*P*S*w*f4*6*3";

		var expected = new GA_CanadianGrainInformation()
		{
			FumigatedCleanedIndicator = "5",
			CommodityCode = "5",
			InspectedWeighedIndicatorCode = "B",
			ReferenceIdentificationQualifier = "hI",
			ReferenceIdentification = "3",
			Week = 4346,
			UnloadTerminalElevatorCode = "JV9",
			Date = "gfOVXbYt",
			Number = 7,
			MachineSeparableIndicatorCode = "pY",
			CanadianWheatBoardCWBMarketingClassCode = "q",
			CanadianWheatBoardCWBMarketingClassTypeCode = "P",
			YesNoConditionOrResponseCode = "S",
			LocationIdentifier = "w",
			StateOrProvinceCode = "f4",
			PercentQualifier = "6",
			Percent = 3,
		};

		var actual = Map.MapObject<GA_CanadianGrainInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "f4", true)]
	[InlineData("w", "", false)]
	[InlineData("", "f4", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "6";
			subject.Percent = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("6", 3, true)]
	[InlineData("6", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.PercentQualifier = percentQualifier;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "w";
			subject.StateOrProvinceCode = "f4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
