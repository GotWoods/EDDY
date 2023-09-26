using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class S2ETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S2E*F";

		var expected = new S2E_SecurityTrailerLevel2()
		{
			HashOrAuthenticationCode = "F",
		};

		var actual = Map.MapObject<S2E_SecurityTrailerLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredHashOrAuthenticationCode(string hashOrAuthenticationCode, bool isValidExpected)
	{
		var subject = new S2E_SecurityTrailerLevel2();
		//Required fields
		//Test Parameters
		subject.HashOrAuthenticationCode = hashOrAuthenticationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
