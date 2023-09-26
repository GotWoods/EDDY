using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ICMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ICM*A*9*4*C*2*WhR";

		var expected = new ICM_IndividualIncome()
		{
			FrequencyCode = "A",
			MonetaryAmount = 9,
			Quantity = 4,
			LocationIdentifier = "C",
			SalaryGrade = "2",
			CurrencyCode = "WhR",
		};

		var actual = Map.MapObject<ICM_IndividualIncome>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredFrequencyCode(string frequencyCode, bool isValidExpected)
	{
		var subject = new ICM_IndividualIncome();
		//Required fields
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.FrequencyCode = frequencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ICM_IndividualIncome();
		//Required fields
		subject.FrequencyCode = "A";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
