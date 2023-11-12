using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class RBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RB*1*U*1*G*j*0*7*f";

		var expected = new RB_RateMinimumDetail()
		{
			AssignedNumber = 1,
			RateApplicationTypeCode = "U",
			FreightRate = 1,
			MinimumWeightLogic = "G",
			LoadingRestriction = "j",
			LoadingRestriction2 = "0",
			Percent = 7,
			ChangeTypeCode = "f",
		};

		var actual = Map.MapObject<RB_RateMinimumDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new RB_RateMinimumDetail();
		subject.RateApplicationTypeCode = "U";
		subject.FreightRate = 1;
		subject.ChangeTypeCode = "f";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredRateApplicationTypeCode(string rateApplicationTypeCode, bool isValidExpected)
	{
		var subject = new RB_RateMinimumDetail();
		subject.AssignedNumber = 1;
		subject.FreightRate = 1;
		subject.ChangeTypeCode = "f";
		subject.RateApplicationTypeCode = rateApplicationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new RB_RateMinimumDetail();
		subject.AssignedNumber = 1;
		subject.RateApplicationTypeCode = "U";
		subject.ChangeTypeCode = "f";
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new RB_RateMinimumDetail();
		subject.AssignedNumber = 1;
		subject.RateApplicationTypeCode = "U";
		subject.FreightRate = 1;
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
