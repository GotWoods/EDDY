using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class RBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RB*5*T*7*D*h*y*7*6";

		var expected = new RB_RateMinimumDetail()
		{
			AssignedNumber = 5,
			RateApplicationTypeCode = "T",
			FreightRate = 7,
			MinimumWeightLogic = "D",
			LoadingRestriction = "h",
			LoadingRestriction2 = "y",
			PercentIntegerFormat = 7,
			ChangeTypeCode = "6",
		};

		var actual = Map.MapObject<RB_RateMinimumDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new RB_RateMinimumDetail();
		subject.RateApplicationTypeCode = "T";
		subject.FreightRate = 7;
		subject.ChangeTypeCode = "6";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredRateApplicationTypeCode(string rateApplicationTypeCode, bool isValidExpected)
	{
		var subject = new RB_RateMinimumDetail();
		subject.AssignedNumber = 5;
		subject.FreightRate = 7;
		subject.ChangeTypeCode = "6";
		subject.RateApplicationTypeCode = rateApplicationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new RB_RateMinimumDetail();
		subject.AssignedNumber = 5;
		subject.RateApplicationTypeCode = "T";
		subject.ChangeTypeCode = "6";
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new RB_RateMinimumDetail();
		subject.AssignedNumber = 5;
		subject.RateApplicationTypeCode = "T";
		subject.FreightRate = 7;
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
