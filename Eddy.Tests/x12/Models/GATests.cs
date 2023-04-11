using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class GATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GA*m*L*J*Ng*c*812227*tde*22A9afnU*6*sZ*z*T*L*w*1s*4*9*L";

		var expected = new GA_CanadianGrainInformation()
		{
			FumigatedCleanedIndicatorCode = "m",
			CommodityCode = "L",
			InspectedWeighedIndicatorCode = "J",
			ReferenceIdentificationQualifier = "Ng",
			ReferenceIdentification = "c",
			Week = 812227,
			UnloadTerminalElevatorCode = "tde",
			Date = "22A9afnU",
			Number = 6,
			MachineSeparableIndicatorCode = "sZ",
			CanadianWheatBoardCWBMarketingClassCode = "z",
			CanadianWheatBoardCWBMarketingClassTypeCode = "T",
			YesNoConditionOrResponseCode = "L",
			LocationIdentifier = "w",
			StateOrProvinceCode = "1s",
			PercentQualifier = "4",
			PercentageAsDecimal = 9,
			YesNoConditionOrResponseCode2 = "L",
		};

		var actual = Map.MapObject<GA_CanadianGrainInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ng", "c", true)]
	[InlineData("", "c", false)]
	[InlineData("Ng", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("w", "1s", true)]
	[InlineData("", "1s", false)]
	[InlineData("w", "", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("4", 9, true)]
	[InlineData("", 9, false)]
	[InlineData("4", 0, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.PercentQualifier = percentQualifier;
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
