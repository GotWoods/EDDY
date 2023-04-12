using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class Y6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y6*HH*M*x9sXJXnT";

		var expected = new Y6_Authentication()
		{
			AuthorityIdentifierCode = "HH",
			Authority = "M",
			AuthorizationDate = "x9sXJXnT",
		};

		var actual = Map.MapObject<Y6_Authentication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredAuthority(string authority, bool isValidExpected)
	{
		var subject = new Y6_Authentication();
		subject.AuthorizationDate = "x9sXJXnT";
		subject.Authority = authority;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x9sXJXnT", true)]
	public void Validation_RequiredAuthorizationDate(string authorizationDate, bool isValidExpected)
	{
		var subject = new Y6_Authentication();
		subject.Authority = "M";
		subject.AuthorizationDate = authorizationDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
