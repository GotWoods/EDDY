using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class C4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "C4*Kne*e";

		var expected = new C4_AlternateAmountDue()
		{
			CurrencyCode = "Kne",
			NetAmountDue = "e",
		};

		var actual = Map.MapObject<C4_AlternateAmountDue>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kne", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new C4_AlternateAmountDue();
		subject.NetAmountDue = "e";
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredNetAmountDue(string netAmountDue, bool isValidExpected)
	{
		var subject = new C4_AlternateAmountDue();
		subject.CurrencyCode = "Kne";
		subject.NetAmountDue = netAmountDue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
