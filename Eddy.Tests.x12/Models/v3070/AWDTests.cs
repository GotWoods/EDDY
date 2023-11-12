using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Tests.Models.v3070;

public class AWDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AWD**4*4*2Ju";

		var expected = new AWD_AmountWithDescription()
		{
			AmountQualifyingDescription = null,
			MonetaryAmount = 4,
			FreeFormMessage = "4",
			CurrencyCode = "2Ju",
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
		subject.MonetaryAmount = 4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(4, "", true)]
	[InlineData(0, "4", true)]
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
	[InlineData(4, "4", false)]
	[InlineData(4, "", true)]
	[InlineData(0, "4", true)]
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
