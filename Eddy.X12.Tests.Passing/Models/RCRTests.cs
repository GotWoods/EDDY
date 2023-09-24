using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RCR*n*Y1";

		var expected = new RCR_ReportingCriteria()
		{
			TimingQualifier = "n",
			ActivityCode = "Y1",
		};

		var actual = Map.MapObject<RCR_ReportingCriteria>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredTimingQualifier(string timingQualifier, bool isValidExpected)
	{
		var subject = new RCR_ReportingCriteria();
		subject.ActivityCode = "Y1";
		subject.TimingQualifier = timingQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y1", true)]
	public void Validation_RequiredActivityCode(string activityCode, bool isValidExpected)
	{
		var subject = new RCR_ReportingCriteria();
		subject.TimingQualifier = "n";
		subject.ActivityCode = activityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
