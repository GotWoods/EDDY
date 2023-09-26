using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class RDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RD*5*5*7*L";

		var expected = new RD_RateData()
		{
			AssignedNumber = 5,
			RateApplicationTypeCode = "5",
			FreightRate = 7,
			ChangeTypeCode = "L",
		};

		var actual = Map.MapObject<RD_RateData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.RateApplicationTypeCode = "5";
		subject.FreightRate = 7;
		subject.ChangeTypeCode = "L";
		//Test Parameters
		if (assignedNumber > 0) 
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredRateApplicationTypeCode(string rateApplicationTypeCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 5;
		subject.FreightRate = 7;
		subject.ChangeTypeCode = "L";
		//Test Parameters
		subject.RateApplicationTypeCode = rateApplicationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 5;
		subject.RateApplicationTypeCode = "5";
		subject.ChangeTypeCode = "L";
		//Test Parameters
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new RD_RateData();
		//Required fields
		subject.AssignedNumber = 5;
		subject.RateApplicationTypeCode = "5";
		subject.FreightRate = 7;
		//Test Parameters
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
