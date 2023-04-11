using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRS*1*R";

		var expected = new PRS_PartReleaseStatus()
		{
			PartReleaseStatusCode = "1",
			Description = "R",
		};

		var actual = Map.MapObject<PRS_PartReleaseStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredPartReleaseStatusCode(string partReleaseStatusCode, bool isValidExpected)
	{
		var subject = new PRS_PartReleaseStatus();
		subject.PartReleaseStatusCode = partReleaseStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
