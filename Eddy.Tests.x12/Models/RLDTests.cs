using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RLDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RLD*kV*5*v*M";

		var expected = new RLD_DownPaymentData()
		{
			TypeOfFundsCode = "kV",
			MonetaryAmount = 5,
			Description = "v",
			AmountQualifierCode = "M",
		};

		var actual = Map.MapObject<RLD_DownPaymentData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 5, true)]
	[InlineData("M", 0, false)]
	public void Validation_ARequiresBAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new RLD_DownPaymentData();
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
