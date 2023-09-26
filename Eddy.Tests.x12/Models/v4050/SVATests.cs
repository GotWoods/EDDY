using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SVATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SVA*Xnb*3*";

		var expected = new SVA_SecurityValue()
		{
			FilterIDCode = "Xnb",
			VersionIdentifier = "3",
			SecurityTokenValue = null,
		};

		var actual = Map.MapObject<SVA_SecurityValue>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xnb", true)]
	public void Validation_RequiredFilterIDCode(string filterIDCode, bool isValidExpected)
	{
		var subject = new SVA_SecurityValue();
		//Required fields
		subject.VersionIdentifier = "3";
		subject.SecurityTokenValue = new C033_SecurityTokenValue();
		//Test Parameters
		subject.FilterIDCode = filterIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredVersionIdentifier(string versionIdentifier, bool isValidExpected)
	{
		var subject = new SVA_SecurityValue();
		//Required fields
		subject.FilterIDCode = "Xnb";
		subject.SecurityTokenValue = new C033_SecurityTokenValue();
		//Test Parameters
		subject.VersionIdentifier = versionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredSecurityTokenValue(string securityTokenValue, bool isValidExpected)
	{
		var subject = new SVA_SecurityValue();
		//Required fields
		subject.FilterIDCode = "Xnb";
		subject.VersionIdentifier = "3";
		//Test Parameters
		if (securityTokenValue != "") 
			subject.SecurityTokenValue = new C033_SecurityTokenValue();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
