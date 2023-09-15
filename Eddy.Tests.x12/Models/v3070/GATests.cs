using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class GATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GA*9*t*f*0P*K*5353*xpe*q7UdZk*6*x7*w*C*f*u*Hv*8*8";

		var expected = new GA_CanadianGrainInformation()
		{
			FumigatedCleanedIndicator = "9",
			CommodityCode = "t",
			InspectedWeighedIndicatorCode = "f",
			ReferenceIdentificationQualifier = "0P",
			ReferenceIdentification = "K",
			Week = 5353,
			UnloadTerminalElevatorCode = "xpe",
			Date = "q7UdZk",
			Number = 6,
			MachineSeparableIndicatorCode = "x7",
			CanadianWheatBoardCWBMarketingClassCode = "w",
			CanadianWheatBoardCWBMarketingClassTypeCode = "C",
			YesNoConditionOrResponseCode = "f",
			LocationIdentifier = "u",
			StateOrProvinceCode = "Hv",
			PercentQualifier = "8",
			Percent = 8,
		};

		var actual = Map.MapObject<GA_CanadianGrainInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredCommodityCode(string commodityCode, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.CommodityCode = commodityCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "u";
			subject.StateOrProvinceCode = "Hv";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "8";
			subject.Percent = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "Hv", true)]
	[InlineData("u", "", false)]
	[InlineData("", "Hv", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.CommodityCode = "t";
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "8";
			subject.Percent = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("8", 8, true)]
	[InlineData("8", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.CommodityCode = "t";
		subject.PercentQualifier = percentQualifier;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "u";
			subject.StateOrProvinceCode = "Hv";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
