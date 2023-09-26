using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class SEFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SEF*J8*N*Fu*H";

		var expected = new SEF_PaymentHandling()
		{
			FrequencyPatternCode = "J8",
			Description = "N",
			PaymentHandlingCode = "Fu",
			Description2 = "H",
		};

		var actual = Map.MapObject<SEF_PaymentHandling>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J8", true)]
	public void Validation_RequiredFrequencyPatternCode(string frequencyPatternCode, bool isValidExpected)
	{
		var subject = new SEF_PaymentHandling();
		//Required fields
		//Test Parameters
		subject.FrequencyPatternCode = frequencyPatternCode;
		//At Least one
		subject.PaymentHandlingCode = "Fu";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Fu", "H", true)]
	[InlineData("Fu", "", true)]
	[InlineData("", "H", true)]
	public void Validation_AtLeastOnePaymentHandlingCode(string paymentHandlingCode, string description2, bool isValidExpected)
	{
		var subject = new SEF_PaymentHandling();
		//Required fields
		subject.FrequencyPatternCode = "J8";
		//Test Parameters
		subject.PaymentHandlingCode = paymentHandlingCode;
		subject.Description2 = description2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
