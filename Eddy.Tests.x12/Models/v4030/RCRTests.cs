using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class RCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RCR*k*hg";

		var expected = new RCR_ReportingCriteria()
		{
			TimingQualifier = "k",
			ActivityCode = "hg",
		};

		var actual = Map.MapObject<RCR_ReportingCriteria>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredTimingQualifier(string timingQualifier, bool isValidExpected)
	{
		var subject = new RCR_ReportingCriteria();
		//Required fields
		subject.ActivityCode = "hg";
		//Test Parameters
		subject.TimingQualifier = timingQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hg", true)]
	public void Validation_RequiredActivityCode(string activityCode, bool isValidExpected)
	{
		var subject = new RCR_ReportingCriteria();
		//Required fields
		subject.TimingQualifier = "k";
		//Test Parameters
		subject.ActivityCode = activityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
