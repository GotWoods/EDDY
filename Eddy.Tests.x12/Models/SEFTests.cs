using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SEFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SEF*WP*f*MH*f";

		var expected = new SEF_PaymentHandling()
		{
			FrequencyPatternCode = "WP",
			Description = "f",
			PaymentHandlingCode = "MH",
			Description2 = "f",
		};

		var actual = Map.MapObject<SEF_PaymentHandling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WP", true)]
	public void Validation_RequiredFrequencyPatternCode(string frequencyPatternCode, bool isValidExpected)
	{
		var subject = new SEF_PaymentHandling();
		subject.FrequencyPatternCode = frequencyPatternCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("MH","f", true)]
	[InlineData("", "f", true)]
	[InlineData("MH", "", true)]
	public void Validation_AtLeastOnePaymentHandlingCode(string paymentHandlingCode, string description2, bool isValidExpected)
	{
		var subject = new SEF_PaymentHandling();
		subject.FrequencyPatternCode = "WP";
		subject.PaymentHandlingCode = paymentHandlingCode;
		subject.Description2 = description2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
