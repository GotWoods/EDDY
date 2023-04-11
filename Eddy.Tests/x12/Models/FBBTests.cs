using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FBBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FBB*mx*9*1*L*N8*3*1";

		var expected = new FBB_ForeignAndIndustryBusiness()
		{
			CountryCode = "mx",
			MonetaryAmount = 9,
			PercentageAsDecimal = 1,
			IdentificationCodeQualifier = "L",
			IdentificationCode = "N8",
			MonetaryAmount2 = 3,
			PercentageAsDecimal2 = 1,
		};

		var actual = Map.MapObject<FBB_ForeignAndIndustryBusiness>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mx", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,0, false)]
	[InlineData(9,1, true)]
	[InlineData(0, 1, true)]
	[InlineData(9, 0, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		subject.CountryCode = "mx";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("L", "N8", true)]
	[InlineData("", "N8", false)]
	[InlineData("L", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		subject.CountryCode = "mx";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}
	//TODO: this test
	//
	// [Theory]
	// [InlineData("",0, true)]
	// [InlineData("L", 3, false)]
	// [InlineData("",3, true)]
	// [InlineData("L", 0, true)]
	// public void Validation_IfOneSpecifiedThenOneMoreRequired_IdentificationCodeQualifier(string identificationCodeQualifier, decimal monetaryAmount2, decimal percentageAsDecimal2, bool isValidExpected)
	// {
	// 	var subject = new FBB_ForeignAndIndustryBusiness();
	// 	subject.CountryCode = "mx";
	// 	subject.IdentificationCodeQualifier = identificationCodeQualifier;
	// 	if (monetaryAmount2 > 0)
	// 	subject.MonetaryAmount2 = monetaryAmount2;
	// 	if (percentageAsDecimal2 > 0)
	// 	subject.PercentageAsDecimal2 = percentageAsDecimal2;
	//
	// 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	// }
	//
}
