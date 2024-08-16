using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class SELTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SEL+C++H";

		var expected = new SEL_SealNumber()
		{
			SealNumber = "C",
			SealIssuer = null,
			SealConditionCoded = "H",
		};

		var actual = Map.MapObject<SEL_SealNumber>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredSealNumber(string sealNumber, bool isValidExpected)
	{
		var subject = new SEL_SealNumber();
		//Required fields
		//Test Parameters
		subject.SealNumber = sealNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
