using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Tests.Models.v3060;

public class SVATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SVA*528*o*";

		var expected = new SVA_SecurityValue()
		{
			FilterIDCode = "528",
			VersionIdentifier = "o",
			SecurityValue = null,
		};

		var actual = Map.MapObject<SVA_SecurityValue>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("528", true)]
	public void Validation_RequiredFilterIDCode(string filterIDCode, bool isValidExpected)
	{
		var subject = new SVA_SecurityValue();
		//Required fields
		subject.VersionIdentifier = "o";
		subject.SecurityValue = new C033_SecurityValue();
		//Test Parameters
		subject.FilterIDCode = filterIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredVersionIdentifier(string versionIdentifier, bool isValidExpected)
	{
		var subject = new SVA_SecurityValue();
		//Required fields
		subject.FilterIDCode = "528";
		subject.SecurityValue = new C033_SecurityValue();
		//Test Parameters
		subject.VersionIdentifier = versionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredSecurityValue(string securityValue, bool isValidExpected)
	{
		var subject = new SVA_SecurityValue();
		//Required fields
		subject.FilterIDCode = "528";
		subject.VersionIdentifier = "o";
		//Test Parameters
		if (securityValue != "") 
			subject.SecurityValue = new C033_SecurityValue();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
