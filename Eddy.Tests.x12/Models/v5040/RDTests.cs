using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class RDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RD*6*m*6*v*Pa8";

		var expected = new RD_RateData()
		{
			AssignedNumber = 6,
			RateApplicationTypeCode = "m",
			FreightRate = 6,
			ChangeTypeCode = "v",
			CurrencyCode = "Pa8",
		};

		var actual = Map.MapObject<RD_RateData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.RateApplicationTypeCode = "m";
		subject.FreightRate = 6;
		subject.ChangeTypeCode = "v";
		subject.CurrencyCode = "Pa8";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredRateApplicationTypeCode(string rateApplicationTypeCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 6;
		subject.FreightRate = 6;
		subject.ChangeTypeCode = "v";
		subject.CurrencyCode = "Pa8";
		//Test Parameters
		subject.RateApplicationTypeCode = rateApplicationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 6;
		subject.RateApplicationTypeCode = "m";
		subject.ChangeTypeCode = "v";
		subject.CurrencyCode = "Pa8";
		//Test Parameters
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 6;
		subject.RateApplicationTypeCode = "m";
		subject.FreightRate = 6;
		subject.CurrencyCode = "Pa8";
		//Test Parameters
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pa8", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 6;
		subject.RateApplicationTypeCode = "m";
		subject.FreightRate = 6;
		subject.ChangeTypeCode = "v";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
