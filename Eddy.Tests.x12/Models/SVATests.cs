using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SVATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SVA*0KW*o*";

		var expected = new SVA_SecurityValue()
		{
			FilterIDCode = "0KW",
			VersionIdentifier = "o",
			SecurityTokenValue = "",
		};

		var actual = Map.MapObject<SVA_SecurityValue>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0KW", true)]
	public void Validation_RequiredFilterIDCode(string filterIDCode, bool isValidExpected)
	{
		var subject = new SVA_SecurityValue();
		subject.VersionIdentifier = "o";
		subject.SecurityTokenValue = "";
		subject.FilterIDCode = filterIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredVersionIdentifier(string versionIdentifier, bool isValidExpected)
	{
		var subject = new SVA_SecurityValue();
		subject.FilterIDCode = "0KW";
		subject.SecurityTokenValue = "";
		subject.VersionIdentifier = versionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validation_RequiredSecurityTokenValue(C033_SecurityTokenValue securityTokenValue, bool isValidExpected)
	{
		var subject = new SVA_SecurityValue();
		subject.FilterIDCode = "0KW";
		subject.VersionIdentifier = "o";
		subject.SecurityTokenValue = securityTokenValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
