using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PPYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPY*lr*2*i*h*V*KC*S";

		var expected = new PPY_PersonalPropertyDescription()
		{
			TypeOfPersonalPropertyCode = "lr",
			MonetaryAmount = 2,
			Description = "i",
			FreeFormMessage = "h",
			FreeFormMessage2 = "V",
			DateTimePeriodFormatQualifier = "KC",
			DateTimePeriod = "S",
		};

		var actual = Map.MapObject<PPY_PersonalPropertyDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lr", true)]
	public void Validation_RequiredTypeOfPersonalPropertyCode(string typeOfPersonalPropertyCode, bool isValidExpected)
	{
		var subject = new PPY_PersonalPropertyDescription();
		//Required fields
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.TypeOfPersonalPropertyCode = typeOfPersonalPropertyCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "KC";
			subject.DateTimePeriod = "S";
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
		subject.TypeOfPersonalPropertyCode = "lr";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "KC";
			subject.DateTimePeriod = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("KC", "S", true)]
	[InlineData("KC", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PPY_PersonalPropertyDescription();
		//Required fields
		subject.TypeOfPersonalPropertyCode = "lr";
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
