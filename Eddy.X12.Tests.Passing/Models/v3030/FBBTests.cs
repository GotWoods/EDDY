using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class FBBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FBB*Mg*3*9*i*cJ*7*8";

		var expected = new FBB_ForeignAndIndustryBusiness()
		{
			CountryCode = "Mg",
			MonetaryAmount = 3,
			Percent = 9,
			IdentificationCodeQualifier = "i",
			IdentificationCode = "cJ",
			MonetaryAmount2 = 7,
			Percent2 = 8,
		};

		var actual = Map.MapObject<FBB_ForeignAndIndustryBusiness>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mg", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		//Test Parameters
		subject.CountryCode = countryCode;
		//At Least one
		subject.MonetaryAmount = 3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "cJ";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || subject.MonetaryAmount2 > 0 || subject.Percent2 > 0)
		{
			subject.IdentificationCodeQualifier = "i";
			subject.MonetaryAmount2 = 7;
			subject.Percent2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(3, 9, true)]
	[InlineData(3, 0, true)]
	[InlineData(0, 9, true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, decimal percent, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "Mg";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		if (percent > 0) 
			subject.Percent = percent;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "cJ";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || subject.MonetaryAmount2 > 0 || subject.Percent2 > 0)
		{
			subject.IdentificationCodeQualifier = "i";
			subject.MonetaryAmount2 = 7;
			subject.Percent2 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "cJ", true)]
	[InlineData("i", "", false)]
	[InlineData("", "cJ", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "Mg";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

        if (subject.IdentificationCodeQualifier != "")
            subject.MonetaryAmount2 = 1;

        //At Least one
        subject.MonetaryAmount = 3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("i", 7, 8, true)]
	[InlineData("i", 0, 0, false)]
	[InlineData("", 7, 8, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_IdentificationCodeQualifier(string identificationCodeQualifier, decimal monetaryAmount2, decimal percent2, bool isValidExpected)
	{
		var subject = new FBB_ForeignAndIndustryBusiness();
		//Required fields
		subject.CountryCode = "Mg";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		if (percent2 > 0) 
			subject.Percent2 = percent2;

        if (subject.IdentificationCodeQualifier != "")
            subject.IdentificationCode = "AB";

        //At Least one
        subject.MonetaryAmount = 3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
