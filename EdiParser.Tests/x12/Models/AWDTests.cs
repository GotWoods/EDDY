using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AWDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AWD**1*9*dOU";

		var expected = new AWD_AmountWithDescription()
		{
		//	AmountQualifyingDescription = "",
			MonetaryAmount = 1,
			FreeFormInformation = "9",
			CurrencyCode = "dOU",
		};

		var actual = Map.MapObject<AWD_AmountWithDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	//TODO: composites
	// [Theory]
	// [InlineData("", false)]
	// [InlineData("", true)]
	// public void Validatation_RequiredAmountQualifyingDescription(C007_AmountQualifyingDescription amountQualifyingDescription, bool isValidExpected)
	// {
	// 	var subject = new AWD_AmountWithDescription();
	// 	subject.AmountQualifyingDescription = amountQualifyingDescription;
	// 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	// }

	[Theory]
	[InlineData(0,"", false)]
	[InlineData(1,"9", true)]
	[InlineData(0, "9", true)]
	[InlineData(1, "", true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, string freeFormInformation, bool isValidExpected)
	{
		var subject = new AWD_AmountWithDescription();
		//subject.AmountQualifyingDescription = "";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		subject.FreeFormInformation = freeFormInformation;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "9", false)]
	[InlineData(0, "9", true)]
	[InlineData(1, "", true)]
	public void Validation_OnlyOneOfMonetaryAmount(decimal monetaryAmount, string freeFormInformation, bool isValidExpected)
	{
		var subject = new AWD_AmountWithDescription();
		//subject.AmountQualifyingDescription = "";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		subject.FreeFormInformation = freeFormInformation;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
