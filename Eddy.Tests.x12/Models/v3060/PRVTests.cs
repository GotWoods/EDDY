using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PRVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRV*b*MO*m*Vg**6Go";

		var expected = new PRV_ProviderInformation()
		{
			ProviderCode = "b",
			ReferenceIdentificationQualifier = "MO",
			ReferenceIdentification = "m",
			StateOrProvinceCode = "Vg",
			ProviderSpecialtyInformation = null,
			ProviderOrganizationCode = "6Go",
		};

		var actual = Map.MapObject<PRV_ProviderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredProviderCode(string providerCode, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ReferenceIdentificationQualifier = "MO";
		subject.ReferenceIdentification = "m";
		//Test Parameters
		subject.ProviderCode = providerCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MO", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ProviderCode = "b";
		subject.ReferenceIdentification = "m";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRV_ProviderInformation();
		//Required fields
		subject.ProviderCode = "b";
		subject.ReferenceIdentificationQualifier = "MO";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
