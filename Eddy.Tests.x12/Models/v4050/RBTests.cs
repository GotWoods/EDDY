using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class RBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RB*2*X*2*f*z*Y*6*T";

		var expected = new RB_RateMinimumDetail()
		{
			AssignedNumber = 2,
			RateApplicationTypeCode = "X",
			FreightRate = 2,
			MinimumWeightLogic = "f",
			LoadingRestriction = "z",
			LoadingRestriction2 = "Y",
			PercentIntegerFormat = 6,
			ChangeTypeCode = "T",
		};

		var actual = Map.MapObject<RB_RateMinimumDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new RB_RateMinimumDetail();
		subject.RateApplicationTypeCode = "X";
		subject.FreightRate = 2;
		subject.ChangeTypeCode = "T";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredRateApplicationTypeCode(string rateApplicationTypeCode, bool isValidExpected)
	{
		var subject = new RB_RateMinimumDetail();
		subject.AssignedNumber = 2;
		subject.FreightRate = 2;
		subject.ChangeTypeCode = "T";
		subject.RateApplicationTypeCode = rateApplicationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new RB_RateMinimumDetail();
		subject.AssignedNumber = 2;
		subject.RateApplicationTypeCode = "X";
		subject.ChangeTypeCode = "T";
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new RB_RateMinimumDetail();
		subject.AssignedNumber = 2;
		subject.RateApplicationTypeCode = "X";
		subject.FreightRate = 2;
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
