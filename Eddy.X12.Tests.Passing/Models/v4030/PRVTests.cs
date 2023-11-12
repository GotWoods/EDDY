using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class PRVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRV*U*aU*7*07**s8t";

		var expected = new PRV_ProviderInformation()
		{
			ProviderCode = "U",
			ReferenceIdentificationQualifier = "aU",
			ReferenceIdentification = "7",
			StateOrProvinceCode = "07",
			ProviderSpecialtyInformation = null,
			ProviderOrganizationCode = "s8t",
		};

		var actual = Map.MapObject<PRV_ProviderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredProviderCode(string providerCode, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "aU";
		subject.ReferenceIdentification = "7";
		//Test Parameters
		subject.ProviderCode = providerCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aU", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ProviderCode = "U";
		subject.ReferenceIdentification = "7";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ProviderCode = "U";
		subject.ReferenceIdentificationQualifier = "aU";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
