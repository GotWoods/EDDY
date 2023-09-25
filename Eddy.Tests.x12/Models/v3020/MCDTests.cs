using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class MCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MCD*3*xgYV7S*2*K";

		var expected = new MCD_MortgageClosingData()
		{
			MonetaryAmount = 3,
			Date = "xgYV7S",
			MonetaryAmount2 = 2,
			Name = "K",
		};

		var actual = Map.MapObject<MCD_MortgageClosingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new MCD_MortgageClosingData();
		//Required fields
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("K", 2, true)]
	[InlineData("K", 0, false)]
	[InlineData("", 2, true)]
	public void Validation_ARequiresBName(string name, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new MCD_MortgageClosingData();
		//Required fields
		subject.MonetaryAmount = 3;
		//Test Parameters
		subject.Name = name;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
