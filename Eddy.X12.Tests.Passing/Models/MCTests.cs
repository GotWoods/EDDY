using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MC*PVK*T5*6*82*3";

		var expected = new MC_MiscellaneousAndAccessorialCharges()
		{
			SpecialChargeOrAllowanceCode = "PVK",
			RateValueQualifier = "T5",
			Rate = 6,
			SpecialChargeDescription = "82",
			AssignedNumber = 3,
		};

		var actual = Map.MapObject<MC_MiscellaneousAndAccessorialCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PVK", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.RateValueQualifier = "T5";
		subject.Rate = 6;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T5", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = "PVK";
		subject.Rate = 6;
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = "PVK";
		subject.RateValueQualifier = "T5";
		if (rate > 0)
		subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
