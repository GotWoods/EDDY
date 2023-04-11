using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class S3ETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S3E*1";

		var expected = new S3E_SecurityTrailerLevel1()
		{
			HashOrAuthenticationCode = "1",
		};

		var actual = Map.MapObject<S3E_SecurityTrailerLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredHashOrAuthenticationCode(string hashOrAuthenticationCode, bool isValidExpected)
	{
		var subject = new S3E_SecurityTrailerLevel1();
		subject.HashOrAuthenticationCode = hashOrAuthenticationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
