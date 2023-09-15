using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class GATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GA*y*u*D*QR*E*923189*QB6*ZcDZx5YP*3*pk*f*4*h*x*OX*h*3*G";

		var expected = new GA_CanadianGrainInformation()
		{
			FumigatedCleanedIndicator = "y",
			CommodityCode = "u",
			InspectedWeighedIndicatorCode = "D",
			ReferenceIdentificationQualifier = "QR",
			ReferenceIdentification = "E",
			Week = 923189,
			UnloadTerminalElevatorCode = "QB6",
			Date = "ZcDZx5YP",
			Number = 3,
			MachineSeparableIndicatorCode = "pk",
			CanadianWheatBoardCWBMarketingClassCode = "f",
			CanadianWheatBoardCWBMarketingClassTypeCode = "4",
			YesNoConditionOrResponseCode = "h",
			LocationIdentifier = "x",
			StateOrProvinceCode = "OX",
			PercentQualifier = "h",
			PercentageAsDecimal = 3,
			YesNoConditionOrResponseCode2 = "G",
		};

		var actual = Map.MapObject<GA_CanadianGrainInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("QR", "E", true)]
	[InlineData("QR", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "x";
			subject.StateOrProvinceCode = "OX";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "h";
			subject.PercentageAsDecimal = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "OX", true)]
	[InlineData("x", "", false)]
	[InlineData("", "OX", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "QR";
			subject.ReferenceIdentification = "E";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "h";
			subject.PercentageAsDecimal = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("h", 3, true)]
	[InlineData("h", 0, false)]
	[InlineData("", 3, false)]
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
			subject.ReferenceIdentification = "E";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "x";
			subject.StateOrProvinceCode = "OX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
