using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class ECSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ECS*s*2*98*S";

		var expected = new ECS_FeesAndPaymentSchedule()
		{
			AmountQualifierCode = "s",
			MonetaryAmount = 2,
			FrequencyPatternCode = "98",
			Description = "S",
		};

		var actual = Map.MapObject<ECS_FeesAndPaymentSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new ECS_FeesAndPaymentSchedule();
		//Required fields
		subject.MonetaryAmount = 2;
		subject.FrequencyPatternCode = "98";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new ECS_FeesAndPaymentSchedule();
		//Required fields
		subject.AmountQualifierCode = "s";
		subject.FrequencyPatternCode = "98";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("98", true)]
	public void Validation_RequiredFrequencyPatternCode(string frequencyPatternCode, bool isValidExpected)
	{
		var subject = new ECS_FeesAndPaymentSchedule();
		//Required fields
		subject.AmountQualifierCode = "s";
		subject.MonetaryAmount = 2;
		//Test Parameters
		subject.FrequencyPatternCode = frequencyPatternCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
