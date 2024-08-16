using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "USL+J+";

		var expected = new USL_SecurityListStatus()
		{
			SecurityStatusCoded = "J",
			ListParameter = null,
		};

		var actual = Map.MapObject<USL_SecurityListStatus>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredSecurityStatusCoded(string securityStatusCoded, bool isValidExpected)
	{
		var subject = new USL_SecurityListStatus();
		//Required fields
		//Test Parameters
		subject.SecurityStatusCoded = securityStatusCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
