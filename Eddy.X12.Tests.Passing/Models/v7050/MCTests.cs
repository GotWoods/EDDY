using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class MCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MC*5OM*UY*6*gs*5";

		var expected = new MC_MiscellaneousAndAccessorialCharges()
		{
			SpecialChargeOrAllowanceCode = "5OM",
			RateValueQualifier = "UY",
			Rate = 6,
			SpecialChargeDescription = "gs",
			AssignedNumber = 5,
		};

		var actual = Map.MapObject<MC_MiscellaneousAndAccessorialCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5OM", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.RateValueQualifier = "UY";
		subject.Rate = 6;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UY", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = "5OM";
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
		subject.SpecialChargeOrAllowanceCode = "5OM";
		subject.RateValueQualifier = "UY";
		if (rate > 0)
			subject.Rate = rate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
