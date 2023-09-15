using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class GATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GA*s*B*Y*8Q*w*571945*e2F*sCcvBYlt*4*aZ*2*7*1*w*6g*K*5*M";

		var expected = new GA_CanadianGrainInformation()
		{
			FumigatedCleanedIndicator = "s",
			CommodityCode = "B",
			InspectedWeighedIndicatorCode = "Y",
			ReferenceIdentificationQualifier = "8Q",
			ReferenceIdentification = "w",
			Week = 571945,
			UnloadTerminalElevatorCode = "e2F",
			Date = "sCcvBYlt",
			Number = 4,
			MachineSeparableIndicatorCode = "aZ",
			CanadianWheatBoardCWBMarketingClassCode = "2",
			CanadianWheatBoardCWBMarketingClassTypeCode = "7",
			YesNoConditionOrResponseCode = "1",
			LocationIdentifier = "w",
			StateOrProvinceCode = "6g",
			PercentQualifier = "K",
			Percent = 5,
			YesNoConditionOrResponseCode2 = "M",
		};

		var actual = Map.MapObject<GA_CanadianGrainInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8Q", "w", true)]
	[InlineData("8Q", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "w";
			subject.StateOrProvinceCode = "6g";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "K";
			subject.Percent = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "6g", true)]
	[InlineData("w", "", false)]
	[InlineData("", "6g", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "8Q";
			subject.ReferenceIdentification = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.Percent > 0)
		{
			subject.PercentQualifier = "K";
			subject.Percent = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("K", 5, true)]
	[InlineData("K", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percent, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.PercentQualifier = percentQualifier;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "8Q";
			subject.ReferenceIdentification = "w";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "w";
			subject.StateOrProvinceCode = "6g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
