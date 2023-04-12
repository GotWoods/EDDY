using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TRS*F*N*9*x*VB";

		var expected = new TRS_TaxRate()
		{
			ActionCode = "F",
			FreeFormDescription = "N",
			PercentageAsDecimal = 9,
			YesNoConditionOrResponseCode = "x",
			RateApplicationCode = "VB",
		};

		var actual = Map.MapObject<TRS_TaxRate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new TRS_TaxRate();
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
