using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TIA*a*1*R";

		var expected = new TIA_TaxInformationAndAmount()
		{
			TaxInformationCode = "a",
			MonetaryAmount = 1,
			FixedFormatInformation = "R",
		};

		var actual = Map.MapObject<TIA_TaxInformationAndAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredTaxInformationCode(string taxInformationCode, bool isValidExpected)
	{
		var subject = new TIA_TaxInformationAndAmount();
		//Required fields
		//Test Parameters
		subject.TaxInformationCode = taxInformationCode;
		//At Least one
		subject.MonetaryAmount = 1;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(1, "R", true)]
	[InlineData(1, "", true)]
	[InlineData(0, "R", true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, string fixedFormatInformation, bool isValidExpected)
	{
		var subject = new TIA_TaxInformationAndAmount();
		//Required fields
		subject.TaxInformationCode = "a";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.FixedFormatInformation = fixedFormatInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
