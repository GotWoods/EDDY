using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class MCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MCD*6*cM2ChF55*4*l";

		var expected = new MCD_MortgageClosingData()
		{
			MonetaryAmount = 6,
			Date = "cM2ChF55",
			MonetaryAmount2 = 4,
			Name = "l",
		};

		var actual = Map.MapObject<MCD_MortgageClosingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
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
	[InlineData("l", 4, true)]
	[InlineData("l", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBName(string name, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new MCD_MortgageClosingData();
		//Required fields
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.Name = name;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
