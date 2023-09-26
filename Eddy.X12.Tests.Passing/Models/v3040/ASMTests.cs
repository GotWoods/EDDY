using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class ASMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ASM*E*E";

		var expected = new ASM_AmountAndSettlementMethod()
		{
			Amount = "E",
			PaymentMethodCode = "E",
		};

		var actual = Map.MapObject<ASM_AmountAndSettlementMethod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new ASM_AmountAndSettlementMethod();
		//Required fields
		//Test Parameters
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
