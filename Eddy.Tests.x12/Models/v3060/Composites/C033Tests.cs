using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Tests.Models.v3060.Composites;

public class C033Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "pkK*p";

		var expected = new C033_SecurityValue()
		{
			SecurityValueQualifier = "pkK",
			EncodedSecurityValue = "p",
		};

		var actual = Map.MapObject<C033_SecurityValue>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pkK", true)]
	public void Validation_RequiredSecurityValueQualifier(string securityValueQualifier, bool isValidExpected)
	{
		var subject = new C033_SecurityValue();
		//Required fields
		subject.EncodedSecurityValue = "p";
		//Test Parameters
		subject.SecurityValueQualifier = securityValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredEncodedSecurityValue(string encodedSecurityValue, bool isValidExpected)
	{
		var subject = new C033_SecurityValue();
		//Required fields
		subject.SecurityValueQualifier = "pkK";
		//Test Parameters
		subject.EncodedSecurityValue = encodedSecurityValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
