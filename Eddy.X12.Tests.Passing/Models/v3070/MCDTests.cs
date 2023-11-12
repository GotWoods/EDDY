using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class MCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MCD*4*KSelCh*9*y";

		var expected = new MCD_MortgageClosingData()
		{
			MonetaryAmount = 4,
			Date = "KSelCh",
			MonetaryAmount2 = 9,
			Name = "y",
		};

		var actual = Map.MapObject<MCD_MortgageClosingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
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
	[InlineData("y", 9, true)]
	[InlineData("y", 0, false)]
	[InlineData("", 9, true)]
	public void Validation_ARequiresBName(string name, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new MCD_MortgageClosingData();
		//Required fields
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.Name = name;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
