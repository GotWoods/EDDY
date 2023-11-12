using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v8020;
using Eddy.x12.Models.v8020.Composites;

namespace Eddy.x12.Tests.Models.v8020.Composites;

public class C077Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "9*DvR*9*Zmw*2*XU6";

		var expected = new C077_CompositeCurrency()
		{
			UnitPrice = 9,
			CurrencyCode = "DvR",
			UnitPrice2 = 9,
			CurrencyCode2 = "Zmw",
			UnitPrice3 = 2,
			CurrencyCode3 = "XU6",
		};

		var actual = Map.MapObject<C077_CompositeCurrency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredUnitPrice(decimal unitPrice, bool isValidExpected)
	{
		var subject = new C077_CompositeCurrency();
		//Required fields
		subject.CurrencyCode = "DvR";
		//Test Parameters
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DvR", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new C077_CompositeCurrency();
		//Required fields
		subject.UnitPrice = 9;
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
