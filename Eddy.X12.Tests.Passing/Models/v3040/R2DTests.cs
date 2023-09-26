using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class R2DTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2D*wMV*R";

		var expected = new R2D_MiscellaneousCharge()
		{
			SpecialChargeOrAllowanceCode = "wMV",
			Amount = "R",
		};

		var actual = Map.MapObject<R2D_MiscellaneousCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wMV", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new R2D_MiscellaneousCharge();
		//Required fields
		subject.Amount = "R";
		//Test Parameters
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new R2D_MiscellaneousCharge();
		//Required fields
		subject.SpecialChargeOrAllowanceCode = "wMV";
		//Test Parameters
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
