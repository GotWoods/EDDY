using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class L9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L9*A0Y*6";

		var expected = new L9_ChargeDetail()
		{
			SpecialChargeOrAllowanceCode = "A0Y",
			Rate = 6,
		};

		var actual = Map.MapObject<L9_ChargeDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A0Y", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new L9_ChargeDetail();
		subject.Rate = 6;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new L9_ChargeDetail();
		subject.SpecialChargeOrAllowanceCode = "A0Y";
		if (rate > 0)
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
