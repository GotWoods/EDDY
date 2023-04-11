using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ICMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ICM*x*2*9*F*n*cFZ";

		var expected = new ICM_IndividualIncome()
		{
			FrequencyCode = "x",
			MonetaryAmount = 2,
			Quantity = 9,
			LocationIdentifier = "F",
			SalaryGrade = "n",
			CurrencyCode = "cFZ",
		};

		var actual = Map.MapObject<ICM_IndividualIncome>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
	{
		var subject = new ICM_IndividualIncome();
		subject.MonetaryAmount = 2;
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ICM_IndividualIncome();
		subject.FrequencyCode = "x";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
