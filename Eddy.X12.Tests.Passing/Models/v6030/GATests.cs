using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class GATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GA*4*o*g*Fh*p*581628*Jbk*2ahz8D7M*2*2D*P*k*n*U*2t*d*1*j";

		var expected = new GA_CanadianGrainInformation()
		{
			FumigatedCleanedIndicatorCode = "4",
			CommodityCode = "o",
			InspectedWeighedIndicatorCode = "g",
			ReferenceIdentificationQualifier = "Fh",
			ReferenceIdentification = "p",
			Week = 581628,
			UnloadTerminalElevatorCode = "Jbk",
			Date = "2ahz8D7M",
			Number = 2,
			MachineSeparableIndicatorCode = "2D",
			CanadianWheatBoardCWBMarketingClassCode = "P",
			CanadianWheatBoardCWBMarketingClassTypeCode = "k",
			YesNoConditionOrResponseCode = "n",
			LocationIdentifier = "U",
			StateOrProvinceCode = "2t",
			PercentQualifier = "d",
			PercentageAsDecimal = 1,
			YesNoConditionOrResponseCode2 = "j",
		};

		var actual = Map.MapObject<GA_CanadianGrainInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Fh", "p", true)]
	[InlineData("Fh", "", false)]
	[InlineData("", "p", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "U";
			subject.StateOrProvinceCode = "2t";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "d";
			subject.PercentageAsDecimal = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "2t", true)]
	[InlineData("U", "", false)]
	[InlineData("", "2t", false)]
	public void Validation_AllAreRequiredLocationIdentifier(string locationIdentifier, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.LocationIdentifier = locationIdentifier;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Fh";
			subject.ReferenceIdentification = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PercentQualifier) || !string.IsNullOrEmpty(subject.PercentQualifier) || subject.PercentageAsDecimal > 0)
		{
			subject.PercentQualifier = "d";
			subject.PercentageAsDecimal = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("d", 1, true)]
	[InlineData("d", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredPercentQualifier(string percentQualifier, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new GA_CanadianGrainInformation();
		subject.PercentQualifier = percentQualifier;
		if (percentageAsDecimal > 0)
			subject.PercentageAsDecimal = percentageAsDecimal;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Fh";
			subject.ReferenceIdentification = "p";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.LocationIdentifier) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.LocationIdentifier = "U";
			subject.StateOrProvinceCode = "2t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
