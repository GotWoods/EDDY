using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ECSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ECS*q*5*Ia*1";

		var expected = new ECS_FeesAndPaymentSchedule()
		{
			AmountQualifierCode = "q",
			MonetaryAmount = 5,
			FrequencyPatternCode = "Ia",
			Description = "1",
		};

		var actual = Map.MapObject<ECS_FeesAndPaymentSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validatation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new ECS_FeesAndPaymentSchedule();
		subject.MonetaryAmount = 5;
		subject.FrequencyPatternCode = "Ia";
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validatation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ECS_FeesAndPaymentSchedule();
		subject.AmountQualifierCode = "q";
		subject.FrequencyPatternCode = "Ia";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ia", true)]
	public void Validatation_RequiredFrequencyPatternCode(string frequencyPatternCode, bool isValidExpected)
	{
		var subject = new ECS_FeesAndPaymentSchedule();
		subject.AmountQualifierCode = "q";
		subject.MonetaryAmount = 5;
		subject.FrequencyPatternCode = frequencyPatternCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
