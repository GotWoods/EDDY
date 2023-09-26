using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PPYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPY*8J*2*s*Z*S*vk*i*Y";

		var expected = new PPY_PersonalPropertyDescription()
		{
			TypeOfPersonalOrBusinessAssetCode = "8J",
			MonetaryAmount = 2,
			Description = "s",
			Description2 = "Z",
			Description3 = "S",
			DateTimePeriodFormatQualifier = "vk",
			DateTimePeriod = "i",
			ReferenceIdentification = "Y",
		};

		var actual = Map.MapObject<PPY_PersonalPropertyDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8J", true)]
	public void Validation_RequiredTypeOfPersonalOrBusinessAssetCode(string typeOfPersonalOrBusinessAssetCode, bool isValidExpected)
	{
		var subject = new PPY_PersonalPropertyDescription();
		//Required fields
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.TypeOfPersonalOrBusinessAssetCode = typeOfPersonalOrBusinessAssetCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "vk";
			subject.DateTimePeriod = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PPY_PersonalPropertyDescription();
		//Required fields
		subject.TypeOfPersonalOrBusinessAssetCode = "8J";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "vk";
			subject.DateTimePeriod = "i";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vk", "i", true)]
	[InlineData("vk", "", false)]
	[InlineData("", "i", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PPY_PersonalPropertyDescription();
		//Required fields
		subject.TypeOfPersonalOrBusinessAssetCode = "8J";
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
