using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class S1ETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S1E*W";

		var expected = new S1E_SecurityTrailerLevel1()
		{
			HashOrAuthenticationCode = "W",
		};

		var actual = Map.MapObject<S1E_SecurityTrailerLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredHashOrAuthenticationCode(string hashOrAuthenticationCode, bool isValidExpected)
	{
		var subject = new S1E_SecurityTrailerLevel1();
		//Required fields
		//Test Parameters
		subject.HashOrAuthenticationCode = hashOrAuthenticationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
