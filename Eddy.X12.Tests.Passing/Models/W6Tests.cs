using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W6*SB*b8*pX*34";

		var expected = new W6_SpecialHandlingInformation()
		{
			SpecialHandlingCode = "SB",
			SpecialHandlingCode2 = "b8",
			SpecialHandlingCode3 = "pX",
			SpecialHandlingCode4 = "34",
		};

		var actual = Map.MapObject<W6_SpecialHandlingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SB", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new W6_SpecialHandlingInformation();
		subject.SpecialHandlingCode = specialHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
