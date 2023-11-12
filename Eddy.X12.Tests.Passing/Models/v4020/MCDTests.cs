using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class MCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MCD*2*is00ruIC*4*5";

		var expected = new MCD_MortgageClosingData()
		{
			MonetaryAmount = 2,
			Date = "is00ruIC",
			MonetaryAmount2 = 4,
			Name = "5",
		};

		var actual = Map.MapObject<MCD_MortgageClosingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("5", 4, true)]
	[InlineData("5", 0, false)]
	[InlineData("", 4, true)]
	public void Validation_ARequiresBName(string name, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new MCD_MortgageClosingData();
		//Required fields
		//Test Parameters
		subject.Name = name;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
