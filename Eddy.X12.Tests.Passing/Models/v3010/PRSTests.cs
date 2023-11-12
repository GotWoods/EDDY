using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PRSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRS*s*b";

		var expected = new PRS_PartReleaseStatus()
		{
			PartReleaseStatusCode = "s",
			Description = "b",
		};

		var actual = Map.MapObject<PRS_PartReleaseStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredPartReleaseStatusCode(string partReleaseStatusCode, bool isValidExpected)
	{
		var subject = new PRS_PartReleaseStatus();
		subject.PartReleaseStatusCode = partReleaseStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
