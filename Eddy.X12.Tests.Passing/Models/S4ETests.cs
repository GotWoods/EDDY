using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class S4ETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S4E*N";

		var expected = new S4E_SecurityTrailerLevel2()
		{
			HashOrAuthenticationCode = "N",
		};

		var actual = Map.MapObject<S4E_SecurityTrailerLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredHashOrAuthenticationCode(string hashOrAuthenticationCode, bool isValidExpected)
	{
		var subject = new S4E_SecurityTrailerLevel2();
		subject.HashOrAuthenticationCode = hashOrAuthenticationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
