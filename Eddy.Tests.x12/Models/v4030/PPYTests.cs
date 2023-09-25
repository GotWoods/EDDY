using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class PPYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PPY*Nq*4*r*8*9*ZX*2*j";

		var expected = new PPY_PersonalPropertyDescription()
		{
			TypeOfPersonalOrBusinessAssetCode = "Nq",
			MonetaryAmount = 4,
			Description = "r",
			Description2 = "8",
			Description3 = "9",
			DateTimePeriodFormatQualifier = "ZX",
			DateTimePeriod = "2",
			ReferenceIdentification = "j",
		};

		var actual = Map.MapObject<PPY_PersonalPropertyDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nq", true)]
	public void Validation_RequiredTypeOfPersonalOrBusinessAssetCode(string typeOfPersonalOrBusinessAssetCode, bool isValidExpected)
	{
		var subject = new PPY_PersonalPropertyDescription();
		//Required fields
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.TypeOfPersonalOrBusinessAssetCode = typeOfPersonalOrBusinessAssetCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ZX";
			subject.DateTimePeriod = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PPY_PersonalPropertyDescription();
		//Required fields
		subject.TypeOfPersonalOrBusinessAssetCode = "Nq";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ZX";
			subject.DateTimePeriod = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZX", "2", true)]
	[InlineData("ZX", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PPY_PersonalPropertyDescription();
		//Required fields
		subject.TypeOfPersonalOrBusinessAssetCode = "Nq";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
