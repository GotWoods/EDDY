using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class Y6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y6*N1*L*oCMI3v";

		var expected = new Y6_Authentication()
		{
			AuthorityIdentifierCode = "N1",
			Authority = "L",
			AuthorizationDate = "oCMI3v",
		};

		var actual = Map.MapObject<Y6_Authentication>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredAuthority(string authority, bool isValidExpected)
	{
		var subject = new Y6_Authentication();
		//Required fields
		subject.AuthorizationDate = "oCMI3v";
		//Test Parameters
		subject.Authority = authority;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oCMI3v", true)]
	public void Validation_RequiredAuthorizationDate(string authorizationDate, bool isValidExpected)
	{
		var subject = new Y6_Authentication();
		//Required fields
		subject.Authority = "L";
		//Test Parameters
		subject.AuthorizationDate = authorizationDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
