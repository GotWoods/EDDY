using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W6*Td*hR*ZT*bn";

		var expected = new W6_SpecialHandlingInformation()
		{
			SpecialHandlingCode = "Td",
			SpecialHandlingCode2 = "hR",
			SpecialHandlingCode3 = "ZT",
			SpecialHandlingCode4 = "bn",
		};

		var actual = Map.MapObject<W6_SpecialHandlingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Td", true)]
	public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
	{
		var subject = new W6_SpecialHandlingInformation();
		//Required fields
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
