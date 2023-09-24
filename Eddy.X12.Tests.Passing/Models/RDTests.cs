using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RD*3*r*6*T*poR";

		var expected = new RD_RateData()
		{
			AssignedNumber = 3,
			RateApplicationTypeCode = "r",
			FreightRate = 6,
			ChangeTypeCode = "T",
			CurrencyCode = "poR",
		};

		var actual = Map.MapObject<RD_RateData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new RD_RateData();
		subject.RateApplicationTypeCode = "r";
		subject.FreightRate = 6;
		subject.ChangeTypeCode = "T";
		subject.CurrencyCode = "poR";
		if (assignedNumber > 0)
		subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredRateApplicationTypeCode(string rateApplicationTypeCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		subject.AssignedNumber = 3;
		subject.FreightRate = 6;
		subject.ChangeTypeCode = "T";
		subject.CurrencyCode = "poR";
		subject.RateApplicationTypeCode = rateApplicationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new RD_RateData();
		subject.AssignedNumber = 3;
		subject.RateApplicationTypeCode = "r";
		subject.ChangeTypeCode = "T";
		subject.CurrencyCode = "poR";
		if (freightRate > 0)
		subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		subject.AssignedNumber = 3;
		subject.RateApplicationTypeCode = "r";
		subject.FreightRate = 6;
		subject.CurrencyCode = "poR";
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("poR", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		subject.AssignedNumber = 3;
		subject.RateApplicationTypeCode = "r";
		subject.FreightRate = 6;
		subject.ChangeTypeCode = "T";
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
