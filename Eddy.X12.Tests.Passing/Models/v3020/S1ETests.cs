using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class S1ETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S1E*EgBV0Gm2E";

		var expected = new S1E_SecurityTrailerLevel1()
		{
			MessageAuthenticationCode = "EgBV0Gm2E",
		};

		var actual = Map.MapObject<S1E_SecurityTrailerLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EgBV0Gm2E", true)]
	public void Validation_RequiredMessageAuthenticationCode(string messageAuthenticationCode, bool isValidExpected)
	{
		var subject = new S1E_SecurityTrailerLevel1();
		//Required fields
		//Test Parameters
		subject.MessageAuthenticationCode = messageAuthenticationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
