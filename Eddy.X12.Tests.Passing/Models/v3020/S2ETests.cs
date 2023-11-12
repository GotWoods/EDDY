using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class S2ETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S2E*HirsnwjF7";

		var expected = new S2E_SecurityTrailerLevel2()
		{
			MessageAuthenticationCode = "HirsnwjF7",
		};

		var actual = Map.MapObject<S2E_SecurityTrailerLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HirsnwjF7", true)]
	public void Validation_RequiredMessageAuthenticationCode(string messageAuthenticationCode, bool isValidExpected)
	{
		var subject = new S2E_SecurityTrailerLevel2();
		//Required fields
		//Test Parameters
		subject.MessageAuthenticationCode = messageAuthenticationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
