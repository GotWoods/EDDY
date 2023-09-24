using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class Y6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y6*eg*x*v7FltWvU";

		var expected = new Y6_Authentication()
		{
			AuthorityIdentifierCode = "eg",
			Authority = "x",
			AuthorizationDate = "v7FltWvU",
		};

		var actual = Map.MapObject<Y6_Authentication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredAuthority(string authority, bool isValidExpected)
	{
		var subject = new Y6_Authentication();
		//Required fields
		subject.AuthorizationDate = "v7FltWvU";
		//Test Parameters
		subject.Authority = authority;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v7FltWvU", true)]
	public void Validation_RequiredAuthorizationDate(string authorizationDate, bool isValidExpected)
	{
		var subject = new Y6_Authentication();
		//Required fields
		subject.Authority = "x";
		//Test Parameters
		subject.AuthorizationDate = authorizationDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
