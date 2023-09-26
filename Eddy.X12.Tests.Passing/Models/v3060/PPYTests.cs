using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PPYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPY*HL*7*I*4*z*0b*O*v";

		var expected = new PPY_PersonalPropertyDescription()
		{
			TypeOfPersonalPropertyCode = "HL",
			MonetaryAmount = 7,
			Description = "I",
			Description2 = "4",
			Description3 = "z",
			DateTimePeriodFormatQualifier = "0b",
			DateTimePeriod = "O",
			ReferenceIdentification = "v",
		};

		var actual = Map.MapObject<PPY_PersonalPropertyDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HL", true)]
	public void Validation_RequiredTypeOfPersonalPropertyCode(string typeOfPersonalPropertyCode, bool isValidExpected)
	{
		var subject = new PPY_PersonalPropertyDescription();
		//Required fields
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.TypeOfPersonalPropertyCode = typeOfPersonalPropertyCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "0b";
			subject.DateTimePeriod = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PPY_PersonalPropertyDescription();
		//Required fields
		subject.TypeOfPersonalPropertyCode = "HL";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "0b";
			subject.DateTimePeriod = "O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0b", "O", true)]
	[InlineData("0b", "", false)]
	[InlineData("", "O", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PPY_PersonalPropertyDescription();
		//Required fields
		subject.TypeOfPersonalPropertyCode = "HL";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
