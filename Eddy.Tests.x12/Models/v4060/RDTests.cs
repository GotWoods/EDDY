using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class RDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RD*8*D*3*N*mTg";

		var expected = new RD_RateData()
		{
			AssignedNumber = 8,
			RateApplicationTypeCode = "D",
			FreightRate = 3,
			ChangeTypeCode = "N",
			CurrencyCode = "mTg",
		};

		var actual = Map.MapObject<RD_RateData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.RateApplicationTypeCode = "D";
		subject.FreightRate = 3;
		subject.ChangeTypeCode = "N";
		subject.CurrencyCode = "mTg";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredRateApplicationTypeCode(string rateApplicationTypeCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 8;
		subject.FreightRate = 3;
		subject.ChangeTypeCode = "N";
		subject.CurrencyCode = "mTg";
		//Test Parameters
		subject.RateApplicationTypeCode = rateApplicationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 8;
		subject.RateApplicationTypeCode = "D";
		subject.ChangeTypeCode = "N";
		subject.CurrencyCode = "mTg";
		//Test Parameters
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 8;
		subject.RateApplicationTypeCode = "D";
		subject.FreightRate = 3;
		subject.CurrencyCode = "mTg";
		//Test Parameters
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mTg", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 8;
		subject.RateApplicationTypeCode = "D";
		subject.FreightRate = 3;
		subject.ChangeTypeCode = "N";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
