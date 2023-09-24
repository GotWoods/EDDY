using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class GATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GA*G*z*o*QR*3*721226*D5w*IsjfAzmd*4*Em*1*P*6*D*1B*I*2*p";

		var expected = new GA_CanadianGrainInformation()
		{
			FumigatedCleanedIndicator = "G",
			CommodityCode = "z",
			InspectedWeighedIndicatorCode = "o",
			ReferenceIdentificationQualifier = "QR",
			ReferenceIdentification = "3",
			Week = 721226,
			UnloadTerminalElevatorCode = "D5w",
			Date = "IsjfAzmd",
			Number = 4,
			MachineSeparableIndicatorCode = "Em",
			CanadianWheatBoardCWBMarketingClassCode = "1",
			CanadianWheatBoardCWBMarketingClassTypeCode = "P",
			YesNoConditionOrResponseCode = "6",
			LocationIdentifier = "D",
			StateOrProvinceCode = "1B",
			PercentQualifier = "I",
			PercentageAsDecimal = 2,
			YesNoConditionOrResponseCode2 = "p",
		};

		var actual = Map.MapObject<GA_CanadianGrainInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QR", "3", true)]
	[InlineData("QR", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "D";
			subject.StateOrProvinceCode = "1B";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "I";
			subject.PercentageAsDecimal = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "1B", true)]
	[InlineData("D", "", false)]
	[InlineData("", "1B", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "QR";
			subject.ReferenceIdentification = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "I";
			subject.PercentageAsDecimal = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("I", 2, true)]
	[InlineData("I", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.PercentQualifier = percentQualifier;
		if (percentageAsDecimal > 0)
			subject.PercentageAsDecimal = percentageAsDecimal;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "QR";
			subject.ReferenceIdentification = "3";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "D";
			subject.StateOrProvinceCode = "1B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
