using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class RICTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RIC*e*3*e*4";

		var expected = new RIC_FinancialReturn()
		{
			ApplicationErrorConditionCode = "e",
			MonetaryAmount = 3,
			CreditDebitFlagCode = "e",
			AccountNumber = "4",
		};

		var actual = Map.MapObject<RIC_FinancialReturn>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredApplicationErrorConditionCode(string applicationErrorConditionCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = "e";
		subject.ApplicationErrorConditionCode = applicationErrorConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "e";
		subject.CreditDebitFlagCode = "e";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
	{
		var subject = new RIC_FinancialReturn();
		subject.ApplicationErrorConditionCode = "e";
		subject.MonetaryAmount = 3;
		subject.CreditDebitFlagCode = creditDebitFlagCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
