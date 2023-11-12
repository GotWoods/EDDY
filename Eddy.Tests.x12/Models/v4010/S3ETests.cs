using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class S3ETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S3E*D";

		var expected = new S3E_SecurityTrailerLevel1()
		{
			HashOrAuthenticationCode = "D",
		};

		var actual = Map.MapObject<S3E_SecurityTrailerLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredHashOrAuthenticationCode(string hashOrAuthenticationCode, bool isValidExpected)
	{
		var subject = new S3E_SecurityTrailerLevel1();
		//Required fields
		//Test Parameters
		subject.HashOrAuthenticationCode = hashOrAuthenticationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
