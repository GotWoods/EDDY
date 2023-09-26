using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class RDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RD*1*j*6*d*UT3";

		var expected = new RD_RateData()
		{
			AssignedNumber = 1,
			RateApplicationTypeCode = "j",
			FreightRate = 6,
			ChangeTypeCode = "d",
			CurrencyCode = "UT3",
		};

		var actual = Map.MapObject<RD_RateData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.RateApplicationTypeCode = "j";
		subject.FreightRate = 6;
		subject.ChangeTypeCode = "d";
		subject.CurrencyCode = "UT3";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredRateApplicationTypeCode(string rateApplicationTypeCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 1;
		subject.FreightRate = 6;
		subject.ChangeTypeCode = "d";
		subject.CurrencyCode = "UT3";
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
		subject.AssignedNumber = 1;
		subject.RateApplicationTypeCode = "j";
		subject.ChangeTypeCode = "d";
		subject.CurrencyCode = "UT3";
		//Test Parameters
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 1;
		subject.RateApplicationTypeCode = "j";
		subject.FreightRate = 6;
		subject.CurrencyCode = "UT3";
		//Test Parameters
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UT3", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 1;
		subject.RateApplicationTypeCode = "j";
		subject.FreightRate = 6;
		subject.ChangeTypeCode = "d";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
