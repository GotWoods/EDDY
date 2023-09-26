using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class AWDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AWD**9*C*dkb";

		var expected = new AWD_AmountWithDescription()
		{
			AmountQualifyingDescription = null,
			MonetaryAmount = 9,
			FreeFormMessage = "C",
			CurrencyCode = "dkb",
		};

		var actual = Map.MapObject<AWD_AmountWithDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAmountQualifyingDescription(string amountQualifyingDescription, bool isValidExpected)
	{
		var subject = new AWD_AmountWithDescription();
		//Required fields
		//Test Parameters
		if (amountQualifyingDescription != "") 
			subject.AmountQualifyingDescription = new C007_AmountQualifyingDescription();
		//At Least one
		subject.MonetaryAmount = 9;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(9, "", true)]
	[InlineData(0, "C", true)]
	public void Validation_AtLeastOneMonetaryAmount(decimal monetaryAmount, string freeFormMessage, bool isValidExpected)
	{
		var subject = new AWD_AmountWithDescription();
		//Required fields
		subject.AmountQualifyingDescription = new C007_AmountQualifyingDescription();
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.FreeFormMessage = freeFormMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(9, "C", false)]
	[InlineData(9, "", true)]
	[InlineData(0, "C", true)]
	public void Validation_OnlyOneOfMonetaryAmount(decimal monetaryAmount, string freeFormMessage, bool isValidExpected)
	{
		var subject = new AWD_AmountWithDescription();
		//Required fields
		subject.AmountQualifyingDescription = new C007_AmountQualifyingDescription();
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.FreeFormMessage = freeFormMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
