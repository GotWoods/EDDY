using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PPYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPY*N0*7*q*0*q*tF*r*m";

		var expected = new PPY_PersonalPropertyDescription()
		{
			TypeOfPersonalPropertyCode = "N0",
			MonetaryAmount = 7,
			Description = "q",
			Description2 = "0",
			Description3 = "q",
			DateTimePeriodFormatQualifier = "tF",
			DateTimePeriod = "r",
			ReferenceNumber = "m",
		};

		var actual = Map.MapObject<PPY_PersonalPropertyDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N0", true)]
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
			subject.DateTimePeriodFormatQualifier = "tF";
			subject.DateTimePeriod = "r";
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
		subject.TypeOfPersonalPropertyCode = "N0";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "tF";
			subject.DateTimePeriod = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("tF", "r", true)]
	[InlineData("tF", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PPY_PersonalPropertyDescription();
		//Required fields
		subject.TypeOfPersonalPropertyCode = "N0";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
