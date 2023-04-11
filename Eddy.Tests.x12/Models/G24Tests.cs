using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G24Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G24*J";

		var expected = new G24_PromotionReference()
		{
			AllowanceOrChargeNumber = "J",
		};

		var actual = Map.MapObject<G24_PromotionReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredAllowanceOrChargeNumber(string allowanceOrChargeNumber, bool isValidExpected)
	{
		var subject = new G24_PromotionReference();
		subject.AllowanceOrChargeNumber = allowanceOrChargeNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
