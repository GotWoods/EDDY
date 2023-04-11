using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class R2DTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2D*NMj*i";

		var expected = new R2D_MiscellaneousCharge()
		{
			SpecialChargeOrAllowanceCode = "NMj",
			Amount = "i",
		};

		var actual = Map.MapObject<R2D_MiscellaneousCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NMj", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new R2D_MiscellaneousCharge();
		subject.Amount = "i";
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new R2D_MiscellaneousCharge();
		subject.SpecialChargeOrAllowanceCode = "NMj";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
