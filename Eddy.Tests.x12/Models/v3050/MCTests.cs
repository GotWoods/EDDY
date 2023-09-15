using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class MCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MC*1LN*G4*4*ok*7";

		var expected = new MC_MiscellaneousAndAccessorialCharges()
		{
			SpecialChargeOrAllowanceCode = "1LN",
			RateValueQualifier = "G4",
			Rate = 4,
			SpecialChargeDescription = "ok",
			AssignedNumber = 7,
		};

		var actual = Map.MapObject<MC_MiscellaneousAndAccessorialCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1LN", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.RateValueQualifier = "G4";
		subject.Rate = 4;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G4", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = "1LN";
		subject.Rate = 4;
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredRate(decimal rate, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = "1LN";
		subject.RateValueQualifier = "G4";
		if (rate > 0)
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
