using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MCD*1*U7bzrJ6I*1*1";

		var expected = new MCD_MortgageClosingData()
		{
			MonetaryAmount = 1,
			Date = "U7bzrJ6I",
			MonetaryAmount2 = 1,
			Name = "1",
		};

		var actual = Map.MapObject<MCD_MortgageClosingData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 1, true)]
	[InlineData("1", 0, false)]
	public void Validation_ARequiresBName(string name, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new MCD_MortgageClosingData();
		subject.Name = name;
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
